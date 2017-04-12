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
            List<MovieModel> list = await rss.getMoviesFromRss();
            List<MovieModel> jsonModels = new List<MovieModel>();
            MovieModel details = new MovieModel();
            JsonManager jsonManager = new JsonManager();
            iApiManager apiManager = new MovieDbApiManager();

            string testresult = "";
            string uri;

            MovieModel jsonModel = new MovieModel();

            /*
            foreach (MovieModel model in list)
            {
                string preparedTitle = model.title.Replace(" ", "+").Replace("3D", "");

                uri = apiManager.GetMovieByTitle(preparedTitle);

                jsonModel = await jsonManager.RetrieveBasic(uri);

                jsonModel = await jsonManager.RetrieveDetails(jsonModel);



                //eredmeny += model.title + ", "  + jsonModel.originalTitle +  ", " + jsonModel.youtubeKey + "\r\n";
                jsonModels.Add(jsonModel);

            }*/
            
           


            //Hibadoboz.Text = rss.eredmeny;
        }
    }
}
