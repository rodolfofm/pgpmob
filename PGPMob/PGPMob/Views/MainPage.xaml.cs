﻿using PGPMob.ViewModels;
using System;
using Xamarin.Forms;

namespace PGPMob.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            var pgpMobApiService = DependencyService.Get<Services.IPGPMobApiService>();
            BindingContext = new MainViewModel(pgpMobApiService);

            menuPage.ListView.ItemSelected += OnItemSelected;

            if (Device.OS == TargetPlatform.Windows)
            {
               // Master.Icon = "swap.png";
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                menuPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

    }
}
