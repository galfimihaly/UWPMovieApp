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
using System.Text.RegularExpressions;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MoziMusor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Test();
                       
        }

        public async void Test()
        {
            RssManager rss = new RssManager();
            List<RssMovieModel> list = await rss.getMoviesFromRss();
            JsonManager jsonManager = new JsonManager();
            iApiManager apiManager = new MovieDbApiManager();

            string eredmeny = "";
            string uri;

            JsonMovieModel jsonModel;

            foreach (RssMovieModel model in list)
            {
                string preparedTitle = model.title.Replace(" ", "+");
                preparedTitle = preparedTitle.Replace("3D", "");

                uri = apiManager.GetMovieByTitle(preparedTitle);


                jsonModel = await jsonManager.RetrieveJson(uri);
                eredmeny += model.title + ", "  + jsonModel.originalTitle + "\r\n" ;
            }


            Hibadoboz.Text = eredmeny;
        }
    }
}
