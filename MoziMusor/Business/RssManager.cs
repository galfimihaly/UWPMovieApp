using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoziMusor.Models;
using Windows.Web.Syndication;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using XmlDocument = Windows.Data.Xml.Dom.XmlDocument;
using XmlElement = Windows.Data.Xml.Dom.XmlElement;

namespace MoziMusor.Business
{
    public class RssManager
    {
        public string eredmeny;

        public Uri RssUri = new Uri("http://www.malommozi.hu/rss.php");

        public async Task<List<MovieModel>> getMoviesFromRss()
        {
            List<DateTime> dates = new List<DateTime>();
            List<MovieModel> list = new List<MovieModel>();

            //lekérdezzük az rss feedet
            
            SyndicationClient client = new SyndicationClient();
            SyndicationFeed feed = await client.RetrieveFeedAsync(RssUri);
            
                       
            //feltöltjük a cím mezőt
            MovieModel model;
            ScreeningModel screeningModel;
            
            foreach (SyndicationItem item in feed.Items)
            {
                model = new MovieModel();

                model.title = item.Title.Text;
                model.link = item.Links.Single().Uri.ToString();


                //itt történik a mágia :D
                string vetites = item.NodeValue;

                vetites = vetites.Substring(vetites.IndexOf('<'))
                    .Replace("<", "").Replace(">", "")
                    .Replace("b", "").Replace("r", "")
                    .Replace("eem", "").Replace(" ", "")
                    .Replace("/", "");

                string[] datas = new string[vetites.Length/10];
                int j = 10;

                for(int i=0; i<datas.Length; i++)
                {

                    if(i == datas.Length-1)
                    {
                        datas[i] = vetites.Substring(j - 10);
                    }
                    else
                    {
                        datas[i] = vetites.Remove(j).Substring(j - 10);

                        j += 10;
                    }

                   
                }

                list.Add(model);                                
            }

            
            return list;
        }
    }
}
