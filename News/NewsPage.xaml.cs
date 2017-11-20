using News.Code;
using News.Helpers;
using News.Models.Responses;
using News.ViewModels;
using Xamarin.Forms;

namespace News
{
    public partial class NewsPage : ContentPage
    {
        NewsViewModel vm = null;
        string source;

        public NewsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadViewModel();
        }

        public void LoadViewModel() {
            Title = Settings.SourceName;

            if (vm == null || source != Settings.Source) {
                source = Settings.Source;
                vm = new NewsViewModel();
                BindingContext = vm;
            }
        }

        async void Change_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewsSource(), true);
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
			=> ((ListView)sender).SelectedItem = null;

		async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var source = ((ListView)sender).SelectedItem as ArticleModel;
			if (source == null)
				return;

            await Navigation.PushAsync(new NewsViewPage(source.Title, source.Url), true);
		}
	}
}