using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;

namespace MoziMusor.Business
{
    public class MovieDbApiManager : iApiManager
    {
        //az api alapja, személyes api kulccsal együtt
        private const string BASIC_API_BASE = "http://api.themoviedb.org/3/search/movie/";
        private const string API_KEY = "?api_key=5a3774eb7ca0790aafd8a6fe14e56228";
        private const string DETAILS_API_BASE = "https://api.themoviedb.org/3/movie/";
        private const string APPEND_VIDEOS = "&append_to_response=videos";
        private const string IMAGE_API_BASE = "https://image.tmdb.org/t/p/";

        //ezzel állíthatjuk be, hogy mekkora méretű képet szeretnénk visszakapni
        private string image_size = "w500";

        private const string QUERY = "&query=";

        private string language = "&language=hu";

        //a film címe alapján a lekérdezés linkjének kialakítása, visszaadása
        public string GetMovieByTitle(string title)
        {
            return string.Format("{0}{1}{2}{3}{4}", BASIC_API_BASE, API_KEY, language, QUERY, title);
        }

        //ha az első lekérdezés sikeres volt, és megvan a filmünk id-je, azzal visszatérünk
        public string GetDetailsById(string key)
        {
            return string.Format("{0}{1}{2}{3}{4}",DETAILS_API_BASE, key, API_KEY, APPEND_VIDEOS, language);
        }


        public string GetMoviePoster(string key)
        {
            return string.Format("{0}{1}{2}", IMAGE_API_BASE, image_size, key);
        }

        //nyelvváltásra későbbiekben
        public void languageChangeTo(string newlang)
        {
            this.language = "&language=" + newlang;
        }

    }
}
