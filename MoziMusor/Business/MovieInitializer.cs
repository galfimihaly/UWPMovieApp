using MoziMusor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoziMusor.Business
{
    public class MovieInitializer
    { 
        public static async Task<List<MovieModel>> InicializeMovies()
        {
            JsonManager jsonManager  = jsonManager = new JsonManager();
            RssManager rssManager = rssManager = new RssManager();
            List<MovieModel> listFromRss = new List<MovieModel>();
            iApiManager  apiManager = new MovieDbApiManager();
            List<MovieModel> models = new List<MovieModel>();
            MovieModel jsonModel;

            string uri;
            string preparedTitle;



            listFromRss = await rssManager.getMoviesFromRss();



            foreach (MovieModel model in listFromRss)
            {
                jsonModel = new MovieModel();

                preparedTitle = model.title.Replace(" ", "+").Replace("3D", "");

                //kiszedjük az ékezeteket, mert a malommozi rss-ében néha el van írva h hosszúak vagy rövidek, ami miatt
                //nem találta meg a moviedb a keresett filmet...
                preparedTitle = Regex.Replace(preparedTitle.Normalize(NormalizationForm.FormD), @"\p{Mn}", "");

                uri = apiManager.GetMovieByTitle(preparedTitle);

                try
                {

                    jsonModel.screenings = model.screenings;

                    jsonModel = await jsonManager.RetrieveBasic(uri);

                    jsonModel = await jsonManager.RetrieveDetails(jsonModel);

                    jsonModel.title = model.title;


                }
                catch
                {
                    jsonModel.overview = "Nem található adat";
                }


                models.Add(jsonModel);
            }

            return models;
        }
    }
}
