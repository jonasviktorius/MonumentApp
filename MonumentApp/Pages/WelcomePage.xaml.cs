using System;
using Windows.UI.Xaml.Controls;
using MonumentApp.Model;
using MonumentApp.Persistency;

namespace MonumentApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            this.InitializeComponent();
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

            
        }

        private void SøgeButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string Text = SøgeBox.Text;
            int id;
            if (int.TryParse(Text, out id))
            {
                FacadeLag facade = new FacadeLag();
                MonumentOversigt nye = facade.HentMonument(id);
                StaticObjects.SelectedMonumenter = nye;
                Hjaelpeklasser.Navigate.To(typeof(MonumentPage));
            }

        }
    }
}
