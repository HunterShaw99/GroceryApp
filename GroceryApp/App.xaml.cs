using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroceryApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            DataManager.DataMgr.GetInstance().LoadData();
        }

        protected override void OnSleep()
        {
            DataManager.DataMgr.GetInstance().SaveData();
        }

        protected override void OnResume()
        {
        }

    }
}
