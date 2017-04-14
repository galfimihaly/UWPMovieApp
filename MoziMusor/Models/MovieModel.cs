using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziMusor.Models
{
    public class MovieModel
    {
        //rss-ből
        public string link;
        public List<ScreeningModel> screenings;

        //az első alap lekérdezésből
        public int id;
        public string title;
        public string originalTitle;
        public string poster;
        public bool adult;
        public float voteAverage;
        public string overview;

        //a második részletes lekérdezésből
        public string youtubeKey;
        public List<string> genres;
        public Double runtime;

    }
}
