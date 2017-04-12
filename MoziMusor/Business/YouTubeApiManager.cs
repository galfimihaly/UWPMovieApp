using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziMusor.Business
{
    public class YouTubeApiManager
    {
        private const string URI_BASE = "https://www.youtube.com/embed/";

        public static string GetYoutubeEmbedUrl(string key)
        {
            return string.Format("{0}{1}", URI_BASE, key);
        }
    }
}
