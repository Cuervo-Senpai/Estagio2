using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ex2_Remasterd_do_Remake
{

    public class Key
    {
        [JsonPropertyName("numberKey")]
        public string NumberKey { get; set; }
        [JsonPropertyName("stars")]
        public List<int> Stars { get; set; }
        [JsonPropertyName("numbers")]
        public List<int> Numbers { get; set; }
        [JsonPropertyName("date")]
        public string Day { get; set; }
        public Key(List<int> stars, List<int> numbers, string date)
        {
            Stars = stars;
            Numbers = numbers;
            Day = date;
        }
    }
}