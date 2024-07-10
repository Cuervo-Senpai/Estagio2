using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections;
using ex2_Remasterd_do_Remake.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using ex2_Remasterd_do_Remake.Models;
using ex2_Remasterd_do_Remake;

namespace Reboot_do_Reboot_2
{
    internal class DataBase
    {
        public static void LoadValuesInDatabase()
        {
            string jsonFilePath = @"C:\EuroMilhões\SavedKeys.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            if (jsonData.Length == 0)
            {
                Console.WriteLine("0 keys in Json");
                return;
            }
            List<Result> keys = JsonConvert.DeserializeObject<List<Result>>(jsonData);
            int count = 0;
            using (var context = new ResultsContext())
            {
                foreach (var key in keys)
                {
                    
                    bool keyExists = context.Results.Any(k => k.NumberKey == key.NumberKey);

                    if (!keyExists)
                    {
                      
                        var newKey = new Results
                        {
                            NumberKey = key.NumberKey,
                            Date = key.Date,
                            Winner = key.Winner,
                            Gain = key.Gain
                        };
                        context.Results.Add(newKey);
                        var newNumber = new Number
                        {
                            NumberKey = key.NumberKey,
                            Number1 = key.Numbers[0],
                            Number2 = key.Numbers[1],
                            Number3 = key.Numbers[2],
                            Number4 = key.Numbers[3],
                            Number5 = key.Numbers[4],
                        };
                        context.Numbers.Add(newNumber);
                        var newStar = new Star
                        {
                            NumberKey = key.NumberKey,
                            Star1 = key.Stars[0],
                            Star2 = key.Stars[1],
                        };
                        context.Stars.Add(newStar);
                        context.SaveChanges();
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            if (count != 0)
            {
                Console.WriteLine($"{count} keys were ignored");
            }
            Console.WriteLine("Processing complete.");
            Thread.Sleep(100);
        }
        public static void LoadValuesFromDatabase()
        {

        }
    }
}