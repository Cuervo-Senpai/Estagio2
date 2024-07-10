using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_Remasterd_do_Remake
{
    internal class Security
    {
        public List<int> UserKeyGenerate(int NumberTowrite, int maxvalue, string type)
        {
            int Number;
            List<int> numbers = [];
            for (int i = 0; i < NumberTowrite; i++)
            {
                Console.WriteLine($"Write a {i+1} {type} (1-{ maxvalue}): ");
                if (i== 0)
                {
                    Number = ConverserStringtoInt();
                    while (KeyRangeValidation(Number, maxvalue))
                    {
                        Console.WriteLine($"Write a {type} between (1-{maxvalue}): ");
                        Number = ConverserStringtoInt();
                    }
                    numbers.Add(Number);
                }
                else
                {
                    Number = ConverserStringtoInt();
                    while (KeyRangeValidation(Number, maxvalue) || KeyValidationRepeatedNumbersInserted(numbers, Number, type))
                    {
                        if (KeyRangeValidation(Number, maxvalue))
                        {
                            Console.WriteLine($"Write a {type} between (-1{maxvalue}):" );
                        }
                        Number = ConverserStringtoInt();
                    }
                    numbers.Add(Number);
                }
            }
            numbers.Sort();
            return numbers;
        }
        public bool KeyValidationRepeatedNumbersInserted(List<int> list, int number, string type)
        {
            if (!list.Contains(number))
            {
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Write a non repeated {type}.");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
        }

        public bool KeyRangeValidation(int number, int maxValve)
        {

            if (number > maxValve || number < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int ConverserStringtoInt()
        {
            bool exit = true;
            int result;
            do
            {

                string? input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Write a Number Please.");
                }


            } while (exit);
            return result;
        }


        public bool RepeatedKeysValidation(List<Key> keyList, Key keyToCheck)
        {
            return keyList.Any(k => k.Numbers.SequenceEqual(keyToCheck.Numbers) && k.Stars.SequenceEqual(keyToCheck.Stars));
        }

        public void GetNumerkey()
        {

        }

        public void DeleteEqualKeysInJason()
        {

        }
    }
    
}
