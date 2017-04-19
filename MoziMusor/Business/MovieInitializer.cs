using MoziMusor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                uri = apiManager.GetMovieByTitle(preparedTitle);

                try
                {

                    jsonModel = await jsonManager.RetrieveBasic(uri);

                    jsonModel = await jsonManager.RetrieveDetails(jsonModel);

                    jsonModel.screenings = model.screenings;

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
