using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigurnost_SQLite_BP
{
    class DatabaseManager
    {
        private static string connectionString = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "testdb.db;";

        //koristi hashirano korime i lozinku (posoljenu) te direktno pretražuje bazu
        public static bool CheckUser(string username, string password)
        {
            int userCount = 0;
           using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "SELECT count(*) FROM zaposlenik as z JOIN odjel as o ON zid = upravitelj WHERE korime = @username AND lozinka = @password";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);
                sQLiteCommand.Parameters.AddWithValue("@username", username);
                sQLiteCommand.Parameters.AddWithValue("@password", password);
                sQLiteCommand.Connection = dbConnection;

                using (sQLiteCommand)
                {
                    using (IDataReader reader = sQLiteCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userCount = reader.GetInt32(0);
                        }
                        reader.Close();
                        dbConnection.Close();
                    }
                }
            }
           if(userCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
