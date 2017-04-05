using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoziMusor.Models;

namespace MoziMusor.Business
{
    public class RssManager
    {
        public string eredmeny;

        public Uri RssUri = new Uri("http://www.malommozi.hu/rss.php");

        public async Task<List<RssMovieViewModel>> getMoviesFromRss()
        {
            List<DateTime> dates = new List<DateTime>();

            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(RssUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            eredmeny = httpResponseBody;

            return new List<RssMovieViewModel>();
        }
    }
}
