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
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MoziMusor.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //A MalomMozi pozíciójának meghatározása
            BasicGeoposition cinemaPosition = new BasicGeoposition() { Latitude = 46.90723, Longitude = 19.68876 };
            Geopoint cinemaCenter = new Geopoint(cinemaPosition);

            //Jelölőikon készítése
            MapIcon malomMapIcon = new MapIcon();
            malomMapIcon.Location = cinemaCenter;
            malomMapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            malomMapIcon.Title = "Malom Központ";
            malomMapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/map_marker-88.png"));
            malomMapIcon.ZIndex = 0;

            //Jelölő hozzáadása a térképhez
            MalomMap.MapElements.Add(malomMapIcon);

            //A pozíció átadása a térképnek.
            MalomMap.Center = cinemaCenter;
            MalomMap.ZoomLevel = 16;
            MalomMap.LandmarksVisible = true;
        }
    }
}
