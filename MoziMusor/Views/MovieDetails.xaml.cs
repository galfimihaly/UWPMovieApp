using MoziMusor.Business;
using MoziMusor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MoziMusor.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieDetails : Page
    {
        MovieModel model;
        App currentApp = Application.Current as App;
        public MovieDetails()
        {
            this.InitializeComponent();

            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                Windows.UI.Core.AppViewBackButtonVisibility.Visible;
            model = new MovieModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            model = currentApp.models.Find(x => x.title == e.Parameter as string);
            

            
            try
            {
                titleTextBox.Text = model.title;
                overviewTextBox.Text = model.overview;
                youtubeWebView.Navigate(new Uri(model.youtubeKey));

                for(int i=0; i<model.screenings.Count; i++)
                {
                    Button reserveButton = new Button();
                    reserveButton.Content = model.screenings.ElementAt(i).time;
                    reserveButton.Click += Button_Click;
                    buttonsStackPanel.Children.Add(reserveButton);                 

                }
                
            }
            catch(Exception ex)
            {
                
            }

        }

        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack && e.Handled == false)
            {
                youtubeVideoStop();
                e.Handled = true;
                Frame.GoBack();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            youtubeVideoStop();
            Button button = (Button)e.OriginalSource;
            ScreeningModel screening = model.screenings.Find(x => x.time.ToString() == button.Content.ToString());
            this.Frame.Navigate(typeof(WebViewPage), ReserveLinkCreator.MakeReserveUri(screening.time, screening.hall));

        }

        private void youtubeVideoStop()
        {
            youtubeWebView.NavigateToString("");
        }
    }
}
