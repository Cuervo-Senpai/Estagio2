using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ex2_Remasterd_do_Remake
{
    internal class SaveCsv
    {
        public static string filePathName = @"C:\ex2 Remasterd do Remake\EuroMillions_numbers.csv";
        public void ReadKeysFromFile()
        {
            string[] lines = File.ReadAllLines(filePathName).Skip(1).ToArray();
            
            foreach (string line in lines)
            {
                string[] parts = line.Split(";");
                if (parts.Length == 10)
                {
                    DateTime date = DateTime.Parse(parts[0]);
                    List<int> numbers = [int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])];
                    List<int> stars = new List<int> { int.Parse(parts[6]), int.Parse(parts[7]) };
                    int winner = int.Parse(parts[8]);
                    long gain = int.Parse(parts[9]);
                    Result result = new Result((Print.results.Count + 1), date, numbers, stars, winner, gain);
                    result.Stars.Sort();
                    result.Numbers.Sort();
                    Print.results.Add(result);
                        
                }
            }
        }
        public void ConvertKeysInResult()
        {
            Random random = new Random();
            foreach (var i in Print.Keys)
            {
                DateTime date = DateTime.Parse(i.Date);
                long gain = random.Next(10000, 10000000);
                int winner = random.Next(0, 3);
                Result result = new Result(Print.results.Count + 1), date, i.Numbers, i.Stars, winner, gain);
                Print.results.Add(result);
            }
        }
        public void SearchKeysInReluts()
        {
            if (Print.results.Count != 0)
            {
                
                Security validation = new Security();
                List<int> numberToSearch = [];
                List<int> starsToSearch = [];
                Console.WriteLine("Do you want search by:\n1-Numbers/Stars\n2-Date\n3-Exit");
                int optionToSearch = validation.ConverserStringtoInt();
                Console.Clear();
                List<Result> foundKeys = new List<Result>();
                do
                {
                    switch (optionToSearch)
                    {
                        case 1:
                            Console.WriteLine("Write a amount numbers you want insert:");
                            int choice = int.Parse(Console.ReadLine());
                            while (choice <= 0 || choice >= 6)
                            {
                                Console.WriteLine($"Write a number between (1-5): ");
                                choice = int.Parse(Console.ReadLine());
                            }
                            for (int i = 0; i < choice; i++)
                            {
                                Console.WriteLine("Write a number to find keys:");
                                numberToSearch.Add(validation.ConverserStringtoInt());
                            }
                            Console.WriteLine("Do you want to search with stars too?\n1-Sim\n2-Não");
                            string choice2 = Console.ReadLine();
                            if (choice2 == "1")
                            {
                                Console.WriteLine("Write a amount stars you want insert:");
                                choice = int.Parse(Console.ReadLine());
                                while (choice <= 0 || choice >= 2)
                                {
                                    Console.WriteLine($"Write a number between (1-2): ");
                                    choice = int.Parse(Console.ReadLine());
                                }
                                for (int i = 0; i < choice; i++)
                                {
                                    Console.WriteLine("Write a number to find keys:");
                                    starsToSearch.Add(validation.ConverserStringtoInt());
                                }
                            }
                            foundKeys = Print.results.Where(k => numberToSearch.All(n => k.Numbers.Contains(n)) && starsToSearch.All(n => k.Stars.Contains(n))).ToList();
                            break;
                        case 2:
                            Console.WriteLine("Write the date you want to search for (Separate with space or -) Day-Month-Year");
                            string date = Console.ReadLine();
                            Console.Clear();
                            string[] dateArrey = new string[4];
                            if (date.Contains(' '))
                            {
                                dateArrey = date.Split(" ");
                            }
                            else if (date.Contains('-'))
                            {
                                dateArrey = date.Split("-");
                            }
                            else
                            {
                                dateArrey = new string[] { date };
                            }
                            int dayInt = 0;
                            int monthInt = 0;
                            int yearInt = 0;
                            if (dateArrey.Length >= 1)
                            {
                                dayInt = dateArrey[0].Length == 0 ? 0 : int.Parse(dateArrey[0]);
                            }
                            if (dateArrey.Length >= 2)
                            {
                                monthInt = dateArrey[1].Length == 0 ? 0 : int.Parse(dateArrey[1]);
                            }
                            if (dateArrey.Length >= 3)
                            {
                                yearInt = dateArrey[2].Length == 0 ? 0 : int.Parse(dateArrey[2]);
                            }
                            foundKeys = Print.results.Where(x => (yearInt == 0 || x.Date.Year == yearInt) && (monthInt == 0 || x.Date.Month == monthInt) && (dayInt == 0 || x.Date.Day == dayInt)).ToList();
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("Select a valid option.");
                            break;
                    }
                } while (optionToSearch >= 3);
                if (foundKeys.Count > 0)
                {
                    if (foundKeys.Count > 0)
                    {
                        if (optionToSearch == 1)
                        {
                            if (starsToSearch.Count != 0)
                            {
                                Console.WriteLine($"Found {foundKeys.Count} keys that contain the number/s ({string.Join(", ", numberToSearch)}) and star/s({string.Join(", ", starsToSearch)}):\n");
                            }
                            else
                            {
                                Console.WriteLine($"Found {foundKeys.Count} keys that contain the number/s ({string.Join(", ", numberToSearch)}):\n");
                            }
                            foreach (var i in foundKeys)
                            {
                                Console.WriteLine($"Date: {i.Date}\nStars: {string.Join(", ", i.Stars)}\nNumbers: {string.Join(", ", i.Numbers)}\nWinner: {i.Winner} Gain: {i.Gain}\n");
                            }
                        }
                        else if (optionToSearch == 2)
                        {
                            Console.WriteLine($"Found {foundKeys.Count} keys that contain the specific date");
                            foreach (var i in foundKeys)
                            {
                                Console.WriteLine($"Date: {i.Date}\nStars: {string.Join(", ", i.Stars)}\nNumbers: {string.Join(", ", i.Numbers)}\nWinner: {i.Winner} Gain: {i.Gain}\n");
                            }
                        }
                    }
                    else
                    {
                        if (starsToSearch.Count != 0)
                        {
                            Console.WriteLine($"No keys found that contain the number/s ({string.Join(", ", numberToSearch)}) and star/s({string.Join(", ", starsToSearch)}).");
                        }
                        else
                        {
                            Console.WriteLine($"No keys found that contain the number/s ({string.Join(", ", numberToSearch)})");
                        }

                    }
                }
            }
        }
    }
}