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
            List<MovieModel> list = new List<MovieModel>();

            //lekérdezzük az rss feedet
            
            SyndicationClient client = new SyndicationClient();
            SyndicationFeed feed = await client.RetrieveFeedAsync(RssUri);
            
                       
            //feltöltjük a cím mezőt
            MovieModel model;
            
            foreach (SyndicationItem item in feed.Items)
            {
                model = new MovieModel();

                model.title = item.Title.Text;
                model.link = item.Links.Single().Uri.ToString();


                //itt történik a mágia :D
                string descriptionString = item.NodeValue;

                descriptionString = descriptionString.Substring(descriptionString.IndexOf('<'))
                    .Replace("<", "").Replace(">", "")
                    .Replace("b", "").Replace("r", "")
                    .Replace("eem", "").Replace(" ", "")
                    .Replace("/", "");

                string[] data = new string[descriptionString.Length/10];
                int j = 10;

                //szétszedjük a stringet 10 karakteres, pontosan elválasztott sorozatokra
                for(int i=0; i<data.Length; i++)
                {

                    if(i == data.Length-1)
                    {
                        data[i] = descriptionString.Substring(j - 10);
                    }
                    else
                    {
                        data[i] = descriptionString.Remove(j).Substring(j - 10);

                        j += 10;
                    }         
                }

                //kinyerjük a konkrét adatokat, feltöltjük a screeningModels listát
                model.screenings = new List<ScreeningModel>();
                DateTime dateTime;
                string day;
                int h;
                for (int i=0; i<data.Length-1; i++)
                {
                    if (data[i].Contains('-'))
                    {
                        day = data[i];
                        i++;
                        while (data[i].Contains(':') && i < data.Length-1)
                        {
                            //(day + ' ' + datas[i]).Remove(16);
                            dateTime = DateTime.ParseExact((day + ' ' + data[i]).Remove(16), "yyyy-MM-dd HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);

                            h = int.Parse(data[i][6].ToString());

                            model.screenings.Add(new ScreeningModel() { time = dateTime, hall = h });
                            i++;
                        }
                        i--;

                    }
                }

                list.Add(model);                                
            }

            
            return list;
        }
    }
}
