using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ex2_Remasterd_do_Remake
{
    internal class Lottery
    {
        Security verification = new();
        RandomNumbers random = new();
        public List<int> GenerateUserNumber()
        {
            List<int> numbers = [];
            numbers = verification.UserKeyGenerate(5, 50, "numbers");
            return numbers;
        }
        public List<int> GenerateUserStars()
        {
            List<int> stras = [];
            stras = verification.UserKeyGenerate(2, 12, "stars");
            return stras;
        }
        public Key CompleteWhitRandomNumbers()
        {
            List<int> stars = random.GenerateStarsRandom(2);
            int wantsNumbers;

            do
            {
                Console.WriteLine("Write a numbers you want insert (0-5): ");
                wantsNumbers = verification.ConverserStringtoInt();
            }while (wantsNumbers <= 1 || wantsNumbers >= 6);
            
                Console.Clear();
                List<int> numbers = verification.UserKeyGenerate(wantsNumbers, 50, "numbers");
                Console.Clear();
                while (numbers.Count != 5) 
                {
                    numbers.AddRange(random.GenerateNumberRandom(5 - wantsNumbers));
                }
                numbers.Sort();
                stars.Sort();
            string day = DateTime.Now.ToString();
            Key key = new Key(stars, numbers, day);
            return key;

        }
        
       
    }    

}
