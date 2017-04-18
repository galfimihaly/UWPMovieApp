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
    public sealed partial class MoviesPage : Page
    {
        App currentApp = Application.Current as App;

        public MoviesPage()
        {
            this.InitializeComponent();
            MovieListView.ItemsSource = currentApp.models;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                Windows.UI.Core.AppViewBackButtonVisibility.Collapsed;


        }

        private void MovieListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var active = e.ClickedItem as MovieModel;
            this.Frame.Navigate(typeof(MovieDetails), active.title);
        }

    }
}
