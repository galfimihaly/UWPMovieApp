using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziMusor.Models
{
    public class DetailsJsonMovieModel
    {
        public BasicJsonMovieModel baseModel;
        public string youtubeKey;
        public string overview;
        public List<string> genres;
        public Double runtime;

        public DetailsJsonMovieModel(BasicJsonMovieModel model)
        {
            this.baseModel = model;
        }

    }
}
