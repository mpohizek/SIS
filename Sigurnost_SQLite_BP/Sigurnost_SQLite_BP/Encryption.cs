using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigurnost_SQLite_BP
{
    class Encryption
    {
        public static string PasswordHashing(string username, string password)
        {
            string salt = "luXaCsGsuEnp3glW7FvB";
            byte[] data = System.Text.Encoding.ASCII.GetBytes(username+password+salt);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }

        public static string Hashing(string inputString)
        {
            string salt = "j7msVKBRRBUnph4OEDi5";
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputString + salt);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
        
        public static string GeneratePassword(int lowercase, int uppercase, int numerics)
        {
            string lowers = "abcdefghijkmnopqrstuvwxyz";
            string uppers = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            string number = "23456789";

            Random random = new Random();

            string generated = "!";
            for (int i = 1; i <= lowercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    lowers[random.Next(lowers.Length - 1)].ToString()
                );

            for (int i = 1; i <= uppercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    uppers[random.Next(uppers.Length - 1)].ToString()
                );

            for (int i = 1; i <= numerics; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    number[random.Next(number.Length - 1)].ToString()
                );

            return generated.Replace("!", string.Empty);
        }
    }
}
