using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GroceryApp
{
    public partial class MainPage : ContentPage, Interfaces.IObserver
    {

        public MainPage()
        {
            InitializeComponent();
            DataManager.DataMgr.GetInstance().RegisterObserver(this);
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailsPage());
        }

        public void Update(List<Models.GroceryItem> value)
        {
            ItemList.ItemsSource = value;
            HideLBL.IsVisible = DataManager.DataMgr.GetInstance().ListEmpty();
        }

        async void ItemList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.GroceryItem groceryItem = (Models.GroceryItem)e.Item;
            await Navigation.PushAsync(new DetailsPage(groceryItem));
        }
    }
}
