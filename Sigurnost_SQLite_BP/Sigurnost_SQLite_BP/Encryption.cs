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
    }
}
