using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoziMusor.Business
{
    public class ReserveLinkCreator
    {
        private const string URI_BASE = "http://www.malommozi.hu/mozimusor?step=1&nap=";

        public static string MakeReserveUri(DateTime date, int hall)
        {
            string datestring = date.ToString("yyyyMMddHHmm");
                //.Year.ToString() + date.Month.ToString()
               // + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString();

            return string.Format("{0}{1}&t={1}00&hall={2}", URI_BASE, datestring ,hall.ToString());
        }

    }
}
