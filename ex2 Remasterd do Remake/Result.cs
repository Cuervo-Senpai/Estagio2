using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_Remasterd_do_Remake
{
    internal class Result
    {
        public DateTime Date { get; set; }
        public List<int> Numbers { get; set; }
        public List<int> Stars { get; set; }
        public int Winner { get; set; }
        public long Gain { get; set; }
        public int NumberKey { get; set; }
        public Result( int numberKey, DateTime date, List<int> numbers, List<int> stars, int winner, long gain)
        {
            NumberKey = numberKey;
            Date = date;
            Numbers = numbers;
            Stars = stars;
            Winner = winner;
            Gain = gain;
        }
    }
}
