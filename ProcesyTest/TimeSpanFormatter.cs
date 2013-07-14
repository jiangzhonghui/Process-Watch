using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcesyTest
{
    class TimeSpanFormatter
    {
        enum format { DaysHoursMinutes, TotalHoursMinutes };

        static format defaultOption = format.TotalHoursMinutes;

        public static string Format(TimeSpan time)
        {
            string formattedTime = "";
            switch (defaultOption)
            {
                case format.DaysHoursMinutes:
                    formattedTime = DaysHoursMinutes(time);
                    break;

                case format.TotalHoursMinutes:
                    formattedTime = TotalHoursMinutes(time);
                    break;
            }

            return formattedTime;
        }

        static string DaysHoursMinutes(TimeSpan time)
        {
            return time.ToString(@"dd\.hh\:mm");
        }

        static string TotalHoursMinutes(TimeSpan time)
        {
            return string.Format("{0:00}:{1:00}",/*Convert.ToInt32*/(time.TotalHours), time.Minutes);
            
        }

        TimeSpanFormatter() { }
    }
}
