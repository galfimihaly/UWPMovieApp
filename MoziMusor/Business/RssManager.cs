using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoziMusor.Models;
using Windows.Web.Syndication;
using System.Xml.Linq;

namespace MoziMusor.Business
{
    public class RssManager
    {
        public string eredmeny;

        public Uri RssUri = new Uri("http://www.malommozi.hu/rss.php");

        public async Task<List<RssMovieViewModel>> getMoviesFromRss()
        {
            List<DateTime> dates = new List<DateTime>();
            List<RssMovieViewModel> list = new List<RssMovieViewModel>();

            

            //lekérdezzük az rss feedet
            
            SyndicationClient client = new SyndicationClient();
            SyndicationFeed feed = await client.RetrieveFeedAsync(RssUri);

            string title = feed.Title.Text;


            RssMovieViewModel model;

            foreach(SyndicationItem item in feed.Items)
            {
                model = new RssMovieViewModel();

               //eredmeny += item.Title.Text;

                model.title = item.Title.Text;
                model.link = item.Links.Single().Uri.ToString();

                list.Add(model);                             
            }

            
            return list;
        }
    }
}
