using MoziMusor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Http;

namespace MoziMusor.Business
{
    public class JsonManager
    {
        private HttpClient client = new HttpClient();

        public async Task<JsonMovieModel> RetrieveJson(string uri)
        {
            JsonMovieModel model = new JsonMovieModel();

            //json kérése
            HttpResponseMessage response = await client.GetAsync(new Uri(uri));
            string result = await response.Content.ReadAsStringAsync();


            JsonObject jsonObj = JsonObject.Parse(result);
            Double count = jsonObj.GetNamedNumber("total_results");

            if(count != 0)
            {
                JsonArray jsonArray = jsonObj.GetNamedArray("results");
                JsonObject movieData = jsonArray.GetObjectAt(0);
                string originalTitle = movieData.GetNamedString("original_title");
                if (originalTitle != "")
                { 
                     model.originalTitle = originalTitle;
                }
                else
                {
                    model.originalTitle = "Nincs angol címe!";
                }
                model.overView = movieData.GetNamedString("overview");

            }
            else
            {
                //mivel mást egyelőre nem használunk fel belőle, biztosítjuk h valamit kapjon
                model.originalTitle = "";
                
            }

            return model;

        }

    }
}
