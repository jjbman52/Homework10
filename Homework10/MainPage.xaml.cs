using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Homework10
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<string> items { get; set; }

        public MainPage()
        {
            items = new ObservableCollection<string>() { "Do you like space", "Do you like to fly", "Do you like to shave"};
            InitializeComponent();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            //put your refreshing logic here
            var itemList = items.Reverse().ToList();
            items.Clear();
            foreach (var s in itemList)
            {
                items.Add(s);
            }
            //make sure to end the refresh state
            list.IsRefreshing = false;
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
        }

        void OnMore(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
        }

        void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            items.Remove(item.CommandParameter.ToString());
        }
    }
}