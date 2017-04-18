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
        public string title { get; set; }
        public string originalTitle { get; set; }
        public string poster { get; set; }
        public bool adult { get; set; }
        public float voteAverage { get; set; } 
        public string overview { get; set; }

        //a második részletes lekérdezésből
        public string youtubeKey;
        public List<string> genres { get; set; }
        public Double runtime { get; set; }

    }
}
