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
using MoziMusor.Models;
using MoziMusor.Business;
using MoziMusor.Views;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MoziMusor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private App currentApp;

        public MainPage()
        {
            this.InitializeComponent();
            currentApp = Application.Current as App;
            InitializeMovies();


            // főoldallal induljon az alkalmazás

            MainFrame.SizeChanged += MainFrame_SizeChanged;



        }

        private async void InitializeMovies()
        {
            currentApp.models = await MovieInitializer.InicializeMovies();
            MainFrame.Navigate(typeof(MoviesPage));
            MoviesListBoxItem.IsSelected = true;
            
        }

        private void MainFrame_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if(e.NewSize.Width >= 1024)
            //{
            //    VisualStateManager.GoToState(MainFrame.Content as Page,
            //        "Desktop", true);
            //}
            //else if(e.NewSize.Width >= 720)
            //{
            //    VisualStateManager.GoToState(MainFrame.Content as Page,
            //        "Tablet", true);
            //}
            //else if (e.NewSize.Width >= 320)
            //{
            //    VisualStateManager.GoToState(MainFrame.Content as Page,
            //        "Mobile", true);
            //}
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MainSliptView.IsPaneOpen = !MainSliptView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MoviesListBoxItem.IsSelected)
            {
                // navigálás
                MainFrame.Navigate(typeof(MoviesPage));
                // fejléc beállítása
                TitleTextBlock.Text = "Moziműsor";
            }
            else if (PricesListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(PricesPage));
                TitleTextBlock.Text = "Árak";
            }
            else if (InfoListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(InfoPage));
                TitleTextBlock.Text = "Információk";
            }
            else if (MapListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(MapPage));
                TitleTextBlock.Text = "Megközelítés";
            }
            else if (AboutListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(AboutPage));
                TitleTextBlock.Text = "Névjegy";
            }

            MainSliptView.IsPaneOpen = false;
        }

    }
}
