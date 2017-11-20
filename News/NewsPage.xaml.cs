using News.Code;
using News.Models.Responses;
using News.ViewModels;
using Xamarin.Forms;

namespace News
{
    public partial class NewsPage : ContentPage
    {
        NewsViewModel vm = null;

        public NewsPage()
        {
            InitializeComponent();
            LoadViewModel();
        }

        public void LoadViewModel() {
            if (vm == null) {
                vm = new NewsViewModel();
                BindingContext = vm;
            }
        }

		void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
			=> ((ListView)sender).SelectedItem = null;

		async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var source = ((ListView)sender).SelectedItem as ArticleResponse;
			if (source == null)
				return;

			//await Navigation.PushAsync(new SourceItem(source.Id), true);
		}
	}
}