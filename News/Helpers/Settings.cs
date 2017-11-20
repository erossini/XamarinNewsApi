// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace News.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

        private const string SourceKey = "source_key";
        private const string SourceNameKey = "sourcename_key";
        private static readonly string SourceDefault = "bbc-news";
        private static readonly string SourceNameDefault = "BCC News";

		#endregion

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
		public static string Source
		{
			get
			{
				return AppSettings.GetValueOrDefault(SourceKey, SourceDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SourceKey, value);
			}
		}

        public static string SourceName
        {
            get
            {
                return AppSettings.GetValueOrDefault(SourceNameKey, SourceNameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SourceNameKey, value);
            }
        }
	}
}