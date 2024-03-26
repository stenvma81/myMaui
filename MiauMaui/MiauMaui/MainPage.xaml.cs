namespace MiauMaui;
using MiauMaui.ViewModels;

public partial class MainPage : ContentPage
{
    MainViewModel viewModel;
    int count = 0;
	string swappable = "Noctropolis";
    bool _isRotating = false;

    public MainPage()
	{
		InitializeComponent();

        BindingContext = new MainViewModel();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        // Append 'a' to the swappable string
        swappable += 'a'; // More concise way to append a character

        // Update the button's text
        CounterBtn.Text = $"Clicked {count} time{(count == 1 ? "" : "s")} {swappable}";

        // Announce the button's text for accessibility purposes
        SemanticScreenReader.Announce(CounterBtn.Text);

        // Perform the rotation animation
        if (!_isRotating) // Start rotation only if not already rotating
        {
            // Rotate from 0 to 360 degrees
            var animation = new Animation(v => CounterBtn.Rotation = v, 0, 360);
            var animation_a = new Animation(v => mainImage.Rotation = v, 360, 0);
            animation_a.Commit(this, "RotationAnimation", 16, 2000, Easing.Linear,
                (v, c) =>
                {
                    mainImage.Rotation = 0; // Reset rotation to 0 for a seamless repeat effect
                    _isRotating = false; // Reset rotation flag
                },
                () => false); // Do not repeat automatically
            animation.Commit(this, "RotationAnimation", 16, 2000, Easing.Linear,
                (v, c) =>
                {
                    CounterBtn.Rotation = 0; // Reset rotation to 0 for a seamless repeat effect
                    _isRotating = false; // Reset rotation flag
                },
                () => false); // Do not repeat automatically
            _isRotating = true; // Set rotation flag
        }
    }

}


