using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcesyTest
{
    class DateTimeFormatter
    {
        public static string FormatShort(DateTime time)
        {
            return time.ToShortTimeString();
        }

        public static string FormatLong(DateTime time)
        {
            return string.Format("{0} {1}", time.ToShortDateString(), time.ToShortTimeString());
        }
    }
}
