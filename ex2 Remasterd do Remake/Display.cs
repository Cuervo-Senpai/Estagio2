using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ex2_Remasterd_do_Remake
{
    static class Print
    {
        public static List<Result> results = new List<Result>();
        public static List<Key> Keys = [];

        public static void ShowKey()
        {
            Console.WriteLine($"Stars: {string.Join(", ", Keys.Last().Stars)}\nNumbers: {string.Join(", ", Keys.Last().Numbers)}");
        }
        public static void ConvertAndSaveKeys()
        {
            SaveJson sj = new SaveJson();
            SaveCsv sv = new SaveCsv();
            sv.ConvertKeysInResult();
            sj.SaveKeysInFile();
        }
        public static void Menu()
        {
            Console.WriteLine("Chose some option to create a number for the Eumillion.\nRandom number - 1\nCreate a number - 2\nNumber of Keys - 3\nComplet numbers - 4\nShow Keys - 5\nDelte Keys - 6\nLottery - 7\nAnalisys- 8\nExit - 9");
        }
        public static void Chose1()
        {
            Security verification = new();
            bool Arequal = false;
            RandomNumbers randomKey = new RandomNumbers();
            do
            {
                Key key = randomKey.GenerateRandomKey();
                if (Arequal)
                {

                }
                else
                {
                    Keys.Add(key);
                    ShowKey();
                }
            } while (Arequal);

        }
        public static void Chose2()
        {
            Security verification = new();
            bool Arequal = false;
            RandomNumbers randomKey = new RandomNumbers();

            do
            {
                Key key = randomKey.CreateUserKey();
                Arequal = verification.RepeatedKeysValidation(Keys, key);
                if (Arequal)
                {
                    Console.Clear();
                    Console.WriteLine("Repeat Key\nInser a new Key");
                }
                else
                {
                    Keys.Add(key);
                    Console.Clear();
                    ShowKey();
                }
            } while (Arequal);
        }
        public static void Chose3()
        {
            Security verification = new();
            bool Arequal = false;
            RandomNumbers randomKey = new RandomNumbers();
            int numbersKey;
            Console.WriteLine("What numbers keys you want?");
            numbersKey = verification.ConverserStringtoInt();
            Console.Clear();

            do
            {
                if (numbersKey < 0)
                {
                    for (int i = numbersKey; i < 0; i++)
                    {
                        if (numbersKey < 0)
                        {
                            Keys.Remove(Keys.Last());
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < numbersKey; i++)
                    {
                        Key key = randomKey.GenerateRandomKey();
                        Arequal = verification.RepeatedKeysValidation(Keys, key);

                        if (Arequal)
                        {

                        }
                        else
                        {
                            if (numbersKey < 0)
                            {
                                Keys.Remove(Keys.Last());
                            }
                            Console.WriteLine("Key " + (i + 1));
                            Keys.Add(key);
                            ShowKey();
                            Console.WriteLine();
                        }
                    }
                }
            } while (Arequal);

        }
        public static void Chose4()
        {
            Security verification = new();
            bool Arequal = false;
            Lottery complet = new Lottery();
            do
            {
                Key key = complet.CompleteWhitRandomNumbers();
                Arequal = verification.RepeatedKeysValidation(Keys, key);
                
                if (Arequal)
                {
                    Console.Clear();
                    Console.WriteLine("Repeat Key\nInser a new Key");

                }
                else
                {
                    Keys.Add(key);
                    Console.Clear();
                    ShowKey();
                }


            } while (Arequal);
        }
        public static void Chose5()
        {
            Console.WriteLine("See Keys - 1\nSee keys in CSV - 2");
            string choice;
            choice = Console.ReadLine();
            
            if(choice == "1")
            {

                int numberKeys = 0;
                Console.WriteLine($"Keys existents: {Keys.Count}");
                if (Keys.Count != 0)
                {
                    Console.Clear();
                }
                foreach (var i in Keys)
                {
                    numberKeys++;
                    Console.WriteLine($"Keys {numberKeys}");
                    Console.WriteLine($"Stars: {string.Join(", ", i.Stars)}\nNumbers: {string.Join(", ", i.Numbers)}");
                }
            }
            if (choice == "2")
            {
                Console.WriteLine("How do you want to organize?\n1-Crescent (oldest to newest)\n2-Decrescent (newest to oldest)");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    results = results.OrderBy(x => x.Date).ToList();
                    
                }
                else if (option == 2)
                {
                    results = results.OrderByDescending(x => x.Date).ToList();
                }
                foreach (var i in results)
                {
                    Console.WriteLine($"Date: {i.Date}\nStars: {string.Join(", ", i.Stars)}\nNumbers: {string.Join(", ", i.Numbers)}\nWinner: {i.Winner} Gain: {i.Gain}");
                }
            }
        }
        public static void chose6()
        {
            File.Delete(SaveJson.filePathName);
            FileStream fs = File.Open(SaveJson.filePathName, FileMode.OpenOrCreate);
            fs.Close();
            Keys.Clear();
            results.Clear();
            SaveCsv sv = new SaveCsv();
            sv.ReadKeysFromFile();
            Console.WriteLine("Deleting Keys...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Deleted keys");
        }
        public static void Chose7()
        {
            Security verification = new();
            bool Arequal = false;
            RandomNumbers randomKey = new RandomNumbers();
            do
            {
                Key winnerkey = randomKey.WinnerKey();
                if (Arequal)
                {

                }
                else
                {
                    Keys.Add(winnerkey);
                }

                Key userkey = randomKey.CreateUserKey();
                Arequal = verification.RepeatedKeysValidation(Keys, userkey);
                if (Arequal)
                {
                    Console.Clear();
                    Console.WriteLine("Repeat Key\nInser a new Key");
                }
                else
                {
                    Keys.Add(userkey);
                    Console.Clear();
                    ShowKey();
                }
                if (winnerkey == userkey)
                {
                    Console.WriteLine("Congratulations");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not congratulations");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"The real winner Key is\nStars: {string.Join(", ", winnerkey.Stars)}\nNumbers: {string.Join(", ", winnerkey.Numbers)}");
                }
            } while (Arequal);
        }
        public static void Chose8()
        {
            
            Console.WriteLine("You want to Search - 1\nYou want a analysis - 2\nTop 5 numbers - 3");
            string choice;
            choice = Console.ReadLine();
            if (choice == "1")
            {
                SaveCsv csv = new();
                csv.SearchKeysInReluts();
            }
            if (choice == "2")
            {
                Analise analysis = new Analise();
                analysis.FrequencyNumber();
            }
            if (choice == "3")
            {
                Analise analise = new Analise();
                analise.TopFiveNumbers();
            }
        }
        public static void DisplayConsole()
        {
            SaveJson file = new();
            SaveCsv csv = new();
            file.SaveFileKeysInList();
            string chose;
            do
            {
                Menu();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                chose = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                switch (chose)
                {
                    case "1":
                        Console.Clear();
                        Chose1();
                        ConvertAndSaveKeys();
                        break;
                    case "2":
                        Console.Clear();
                        Chose2();
                        ConvertAndSaveKeys();
                        break;
                    case "3":
                        Console.Clear();
                        Chose3();
                        ConvertAndSaveKeys();
                        break;
                    case "4":
                        Console.Clear();
                        Chose4();
                        ConvertAndSaveKeys();
                        break;
                    case "5":
                        Console.Clear();
                        Chose5();
                        break;
                    case "6":
                        Console.Clear();
                        chose6();
                        break;
                    case "7":
                        Console.Clear();
                        Chose7();
                        break;
                    case "8":
                        Console.Clear();
                        Chose8();
                        break;
                    case "9":
                        Console.Clear();
                                Console.WriteLine("GoodBye");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Chose a correct option\nPlease");
                        Console.WriteLine("----------------------");
                        break;
                }
            } while (chose != "9");
        }
    }
}