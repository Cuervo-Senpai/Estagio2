using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_Remasterd_do_Remake
{
    internal class RandomNumbers
    {
        Random random = new Random();
        public List<int> GenerateNumberRandom(int numbersgenerate)
        {
            List<int> numbers = [];
            int number;
            while (numbers.Count() != numbersgenerate)
            {
                number = random.Next(1, 51);
                while(numbers.Contains(number))
                {
                    number = random.Next(1, 51);
                }
                numbers.Add(number);
            }
            numbers.Sort();
            return numbers;
        }
        public List<int> GenerateStarsRandom(int starsgenerate)
        {
            List<int> stars = [];
            int star;
            while (stars.Count() != starsgenerate)
            {
                star = random.Next(1, 13);
                while(stars.Contains(star))
                {
                    star = random.Next(1, 13);
                }
                stars.Add(star);
            }
            stars.Sort();
            return stars;
        }
        public Key GenerateRandomKey()
        {
            List<int> number = GenerateNumberRandom(5);
            List<int> star = GenerateStarsRandom(2);
            string day = DateTime.Now.ToString();
            Key key = new Key(star, number, day);
            return key;
        }
        public Key CreateUserKey()
        {
            Lottery lottery = new Lottery();
            List<int> number = lottery.GenerateUserNumber();
             List<int> star = lottery.GenerateUserStars();
            string day = DateTime.Now.ToString();
            Key key = new Key(star, number, day);
            return key;
        }
        public Key WinnerKey()
        {
            List<int> number = GenerateNumberRandom(5);
            List<int> stars = GenerateStarsRandom(2);
            string day = DateTime.Now.ToString();
            Key winnerKey = new Key(number, stars, day);
            return winnerKey;   
        }
        public string GetKeyNumber()
        {
            int number;
            if (Print.Keys.Count <= 0)
            {
                return "1";
            }
            else
            {
                number = Print.Keys.Count() + 1;
                return number.ToString();
            }
        }
    }
}
