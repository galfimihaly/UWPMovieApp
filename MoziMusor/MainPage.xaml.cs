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
            List<JsonMovieModel> jsonModels = new List<JsonMovieModel>();
            JsonMovieModel details = new JsonMovieModel();
            JsonManager jsonManager = new JsonManager();
            iApiManager apiManager = new MovieDbApiManager();

            string eredmeny = "";
            string uri;
            string detailsUri;

            JsonMovieModel jsonModel = new JsonMovieModel();

            foreach (RssMovieModel model in list)
            {
                string preparedTitle = model.title.Replace(" ", "+").Replace("3D", "");

                uri = apiManager.GetMovieByTitle(preparedTitle);

                jsonModel = await jsonManager.RetrieveBasic(uri);

                jsonModel = await jsonManager.RetrieveDetails(jsonModel);


                eredmeny += model.title + ", "  + jsonModel.originalTitle +  ", " + jsonModel.runtime + "\r\n";
                jsonModels.Add(jsonModel);

            }

            
            //eredmeny += jsonModel.youtubeKey + "\r\n";
            
           


            Hibadoboz.Text = eredmeny;
        }
    }
}
