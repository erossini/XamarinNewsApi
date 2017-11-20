using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace News
{
    public partial class NewsViewPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:News.NewsViewPage"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="url">URL.</param>
        public NewsViewPage(string title, string url)
        {
            InitializeComponent();

            this.titleLabel.Text = title;
            this.webview1.Source = url;
        }
    }
}