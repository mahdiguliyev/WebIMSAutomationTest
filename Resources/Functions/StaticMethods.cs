using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resources.Functions
{
    public static class StaticMethods
    {
        private static Random random = new Random();
        public static string[] SplitData(string regex, string data)
        {
            string[] splittedData = data.Split(regex);
            return splittedData;
        }
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateVehicleRegNumber()
        {
            Random random = new Random();
            int firstTwoNumber = random.Next(10, 99);
            int lastThereNumber = random.Next(100, 999);

            StringBuilder stringBuilder = new StringBuilder();

            char letter;

            for (int i = 0; i < 2; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                stringBuilder.Append(letter);
            }

            return $"{firstTwoNumber}{stringBuilder.ToString()}{lastThereNumber}";
        }

        public static int GenerateVehicleRegCertNumber()
        {
            Random random = new Random();
            var number = random.Next(10000000, 99999999);

            return number;
        }

        public static string GenerateVehicleVinNumber()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomString = new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var number = random.Next(1000000, 9999999);

            return $"{randomString}{number.ToString()}";
        }

        public static string GenerateVehicleBodyNumber()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomString = new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var number = random.Next(100000000, 999999999);

            return $"{randomString}{number.ToString()}";
        }
    }
}
