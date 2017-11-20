using System;
using System.Collections.Generic;
using News.Helpers;
using News.Models.Responses;
using News.ViewModels;
using Xamarin.Forms;

namespace News
{
    public partial class NewsSource : ContentPage
    {
        NewsSourceViewModel vm = null;

        public NewsSource()
        {
            InitializeComponent();
            LoadViewModel();
        }

        public void LoadViewModel()
        {
            if (vm == null)
            {
                vm = new NewsSourceViewModel();
                BindingContext = vm;
            }
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var source = ((ListView)sender).SelectedItem as SourceModel;
            if (source == null)
                return;

            Settings.Source = source.Id;
            Settings.SourceName = source.Name;

            await Navigation.PopAsync(true);
        }
    }
}