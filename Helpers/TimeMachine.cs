using Periodic.Models;
using System.Runtime.InteropServices;

namespace Periodic.Helpers
{
    public class TimeMachine
    {
        public static DateTime UnixToDateTime(ulong unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public static ulong DateTimeToUnix(DateTime datetime)
        {
            var dto = new DateTimeOffset(datetime.ToUniversalTime());
            return (ulong)dto.ToUnixTimeSeconds();

        }
        
        //returns the datetime of next occurence of transaction
        public static IEnumerable<DateTime> GetAllOccurences(DateTime startDate, Char freq, int stepSize, DateTime endDate)
        {
            var next_occur_list = new List<DateTime>();
            int count = 0;

            var next_occur = startDate;

            while(next_occur <= endDate)
            {
                next_occur_list.Add(next_occur);

                switch (freq)
                {
                    case 'Y':
                        next_occur = next_occur.AddYears(stepSize);
                        break;

                    case 'M':
                        next_occur = next_occur.AddMonths(stepSize);
                        break;

                    case 'W':
                        next_occur = next_occur.AddDays(7 * stepSize);
                        break;

                    case 'D':
                        next_occur = next_occur.AddDays(stepSize);
                        break;
                }
                
            }
            return next_occur_list;
        }
    }
}