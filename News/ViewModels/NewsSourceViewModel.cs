using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using News.Code;
using News.Models.Responses;
using PSC.Xamarin.MvvmHelpers;

namespace News.ViewModels
{
    public class NewsSourceViewModel : BaseViewModel
    {
        public ObservableCollection<SourceModel> SourceList { get; set; }

        public NewsSourceViewModel()
        {
            LoadData();
        }

        async Task LoadData()
        {
            ShowEmpty = true;
            ShowListView = false;
            IsBusy = true;

            NewsClient client = new NewsClient();
            SourceResponse sources = await client.GetSources(Constants.ApiKey);
            if (sources != null && sources.Status.ToLower() == "ok")
            {
                SourceList = new ObservableCollection<SourceModel>(sources.Sources);
                if (SourceList.Count > 0)
                {
                    ShowEmpty = false;
                    ShowListView = true;
                }
                OnPropertyChanged(nameof(SourceList));
            }

            IsBusy = false;
        }
        
        #region Models
        /// <summary>
        /// The show empty
        /// </summary>
        bool _showEmpty;

        /// <summary>
        /// The show ListView
        /// </summary>
        bool _showListView;

        /// <summary>
        /// Gets or sets a value indicating whether the list is empty
        /// </summary>
        /// <value><c>true</c> if {show empty}; otherwise, <c>false</c>.</value>
        public bool ShowEmpty
        {
            get
            {
                return _showEmpty;
            }
            set
            {
                if (_showEmpty != value)
                {
                    _showEmpty = value;
                    OnPropertyChanged(nameof(ShowEmpty));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the list is full
        /// </summary>
        /// <value><c>true</c> if {show ListView}; otherwise, <c>false</c>.</value>
        public bool ShowListView
        {
            get
            {
                return _showListView;
            }
            set
            {
                if (_showListView != value)
                {
                    _showListView = value;
                    OnPropertyChanged(nameof(ShowListView));
                }
            }
        }
        #endregion
    }
}