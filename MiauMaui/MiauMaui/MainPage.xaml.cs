namespace MiauMaui;

public partial class MainPage : ContentPage
{
	int count = 0;
	string swappable = "Noctropolis";

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
        string newString = swappable + 'a';
        swappable = newString;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time {swappable}";
		else
			CounterBtn.Text = $"Clicked {count} timessss {swappable}";

        var animation = new Animation(v => CounterBtn.Rotation = v, 0, 360);
        animation.Commit(this, "RotationAnimation", 16, 1000, Easing.Linear, (v, c) => CounterBtn.Rotation = 0, () => true);

        SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


