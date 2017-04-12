using MoziMusor.Models;
using System;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Http;

namespace MoziMusor.Business
{
    public class JsonManager
    {
        private HttpClient client = new HttpClient();

        public async Task<JsonMovieModel> RetrieveBasic(string uri)
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
                string overView = movieData.GetNamedString("overview");
                model.id = (int)movieData.GetNamedNumber("id");
                model.voteAverage = (float)movieData.GetNamedNumber("vote_average");
                model.overview = overView;
                model.poster = movieData.GetNamedString("poster_path");
                

                if (originalTitle != "")
                {
                    model.originalTitle = originalTitle;
                }
                else
                {
                    model.originalTitle = "Nincs angol címe!";
                }

            }
            else
            {
                //mivel mást egyelőre nem használunk fel belőle, biztosítjuk h valamit kapjon
                model.originalTitle = "";
                
            }

            return model;
        }


        public async Task<JsonMovieModel> RetrieveDetails(JsonMovieModel model)
        {

            MovieDbApiManager dbApi = new MovieDbApiManager();

            
            HttpResponseMessage response = await client.GetAsync(new Uri(dbApi.GetDetailsById(model.id.ToString())));
            string result = await response.Content.ReadAsStringAsync();

            var jsonObj = JsonObject.Parse(result);


            try
            {
                model.runtime = jsonObj.GetNamedNumber("revenue");

                //model.youtubeKey = jsonObj["videos"]["results"];


            }
            catch
            {
                model.runtime = 0;
            }

            return model;
        }

    }
}
