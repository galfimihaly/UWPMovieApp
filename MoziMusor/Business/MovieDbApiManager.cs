using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziMusor.Business
{
    public class MovieDbApiManager : iApiManager
    {
        //az api alapja, személyes api kulccsal együtt
        private const string API_BASE = "http://api.themoviedb.org/3/search/movie/?api_key=5a3774eb7ca0790aafd8a6fe14e56228";

        private const string query = "&query=";

        private string language = "&language=hu";

        //a film címe alapján a lekérdezés linkjének kialakítása, visszaadása
        public string GetMovieByTitle(string title)
        {
            return string.Format("{0}{1}{2}{3}", API_BASE, language, query, title);
        }

        //nyelvváltásra későbbiekben
        public string languageChangeTo(string newlang)
        {
            return this.language = "&language=" + newlang;
        }

    }
}
