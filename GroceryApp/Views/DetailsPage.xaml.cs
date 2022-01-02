using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroceryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {

        Boolean isEdit;
        Models.GroceryItem itemFocused;

        readonly List<string> categoryLIST = new List<string>(14) {
            "Baking", "Beverages", "Bread", "Cereal",
            "Candy and Snacks", "Canned","Condiments", "Dairy",
            "Boxed Food and Pasta", "Paper and Cleaning",
            "Meat", "Personal Care", "Alcohol", "Tobacco",
            "Lottery"};
        
        public DetailsPage()
        {
            InitializeComponent();
            picker.ItemsSource = categoryLIST;
            DeleteBTN.IsVisible = false;
            isEdit = false;
        }

        public DetailsPage(Models.GroceryItem toEdit)
        {
            InitializeComponent();
            itemFocused = toEdit;
            NameField.Text = itemFocused.Name;
            QuantityField.Text = itemFocused.Quantity.ToString();
            picker.ItemsSource = categoryLIST;
            int categoryIndex = SearchList(categoryLIST, itemFocused.Category);
            picker.SelectedIndex = categoryIndex;
            DeleteBTN.IsVisible = true;
            isEdit = true;
        }

        override protected void OnDisappearing()
        {
            itemFocused = null;
        }

        void SaveBTN_Clicked(object sender, EventArgs e)
        {
            NameField.Text = TrimText(NameField.Text);
            if (NameField.Text != null && NameField.Text.Length > 0)
            {
                decimal.TryParse(QuantityField.Text, out decimal quantity);
                switch (isEdit)
                {
                    case true:
                        // Update an existing item in DataMgr
                        DataManager.DataMgr.GetInstance().UpdateItem(itemFocused.ItemID, NameField.Text, quantity == 0 ? null : quantity, picker.SelectedIndex == -1 ? null : categoryLIST[picker.SelectedIndex]);
                        break;
                    case false:
                        DataManager.DataMgr.GetInstance().AddItem(new Models.GroceryItem(NameField.Text, quantity == 0 ? null : quantity, picker.SelectedIndex == -1 ? null : categoryLIST[picker.SelectedIndex]));
                        break;
                }
                Navigation.PopAsync();
            }
            else
            {
                ShowError();
            }
        }

        void CancelBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        int SearchList(List<string> lst, string toFind)
        {
            int index = -1;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Equals(toFind))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        String TrimText(string input)
        {
            string output;
            if (input == null)
            {
                output = "";
            }
            else
            {
                output = input.Trim();
            }
            return output;
        }

        async void ShowError()
        {
            await DisplayAlert("Error", "Name field is required", "OK");
        }

        void DeleteBTN_Clicked(object sender, EventArgs e)
        {
            //Delete the item
            DataManager.DataMgr.GetInstance().DeleteItem(itemFocused);
            Navigation.PopAsync();
        }
    }
}