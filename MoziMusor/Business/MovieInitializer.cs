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
            iApiManager  apiManager = new MovieDbApiManager();
            List<MovieModel> models = new List<MovieModel>();



            List<MovieModel> listFromRss = new List<MovieModel>();
            listFromRss = await rssManager.getMoviesFromRss();

            MovieModel jsonModel = new MovieModel();

            string uri;
            string preparedTitle;

            foreach (MovieModel model in listFromRss)
            {
                preparedTitle = model.title.Replace(" ", "+").Replace("3D", "");

                uri = apiManager.GetMovieByTitle(preparedTitle);

                try
                {
                    jsonModel = await jsonManager.RetrieveBasic(uri);

                    jsonModel = await jsonManager.RetrieveDetails(jsonModel);
                }
                catch
                {
                    jsonModel.overview = "Nem található adat";
                }

                //jsonModel = await jsonManager.RetrieveImage(jsonModel);


                models.Add(jsonModel);
            }

            return models;
        }
    }
}
