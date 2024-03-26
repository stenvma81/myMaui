using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MiauMaui.Models; // Ensure you're using the correct namespace for your models
using System.Linq;

namespace MiauMaui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DataClass> Items { get; set; } = new ObservableCollection<DataClass>();

        public MainViewModel()
        {
            AddDefaultItems();
        }

        private void AddDefaultItems()
        {
            // Initialize the ObservableCollection with some default items
            Items.Add(new DataClass { Title = "KArvaperseenSuo!", IsDone = false });
            Items.Add(new DataClass { Title = "Build an awesome app", IsDone = false });
            Items.Add(new DataClass { Title = "Publish app to store", IsDone = false });
            Items.Add(new DataClass { Title = "PSebulba", IsDone = false });
            Items.Add(new DataClass { Title = "sdffds gfd to store", IsDone = false });
            Items.Add(new DataClass { Title = "Pubdsfdsflish dfgdf h store", IsDone = false });
            Items.Add(new DataClass { Title = "Publidsffdssh app to store", IsDone = false });
        }

        public void AddItem(string title)
        {
            var newItem = new DataClass { Title = title, IsVisible = true };
            Items.Add(newItem);
        }

        public void ToggleIsDone(string id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.IsDone = !item.IsDone;
                // No need to call OnPropertyChanged for individual item property changes in the collection
            }
        }

        public void ToggleVisibility(string id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.IsVisible = !item.IsVisible;
                // Refresh the collection if you filter items based on visibility in your view
                RefreshVisibleItems();
            }
        }

        // Optional: Method to refresh or filter items based on visibility
        // This example method presumes you have a way to refresh or reassign Items collection in your view
        private void RefreshVisibleItems()
        {
            // Depending on how you've set up your view, you might need to implement a mechanism to refresh 
            // or filter the Items collection based on the IsVisible property.
            // This could involve resetting the ItemsSource of your ListView/CollectionView, 
            // creating a new ObservableCollection with filtered items, or implementing a more dynamic 
            // approach to managing and displaying your collection.
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
