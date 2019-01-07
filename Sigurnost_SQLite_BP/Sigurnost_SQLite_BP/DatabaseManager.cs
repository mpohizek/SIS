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
        private static string connectionString = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "testdb.db;foreign keys=true;";

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

        public static bool AddDepartment(Department department)
        {
            int numRowsAffected = 0;
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "INSERT INTO odjel values (null, @name, @employee)";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);

                sQLiteCommand.Parameters.AddWithValue("@name", department.Name);
                sQLiteCommand.Parameters.AddWithValue("@employee", department.Manager);
                sQLiteCommand.Connection = dbConnection;
                try
                {
                    numRowsAffected = sQLiteCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    dbConnection.Close();
                    return false;
                }
                dbConnection.Close();
            }
            if(numRowsAffected <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool AddEmployee(Employee employee)
        {
            int numRowsAffected = 0;
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "INSERT INTO zaposlenik values (null, @firstName, @lastName, @username, " +
                    "@address, @password, @depId, @bankAcc, @email)";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);

                sQLiteCommand.Parameters.AddWithValue("@firstName", employee.FirstName);
                sQLiteCommand.Parameters.AddWithValue("@lastName", employee.LastName);
                sQLiteCommand.Parameters.AddWithValue("@username", employee.Username);
                sQLiteCommand.Parameters.AddWithValue("@address", employee.Address);
                sQLiteCommand.Parameters.AddWithValue("@password", employee.Password);
                sQLiteCommand.Parameters.AddWithValue("@depId", employee.DepId);
                sQLiteCommand.Parameters.AddWithValue("@bankAcc", employee.BankAcc);
                sQLiteCommand.Parameters.AddWithValue("@email", employee.Email);
                sQLiteCommand.Connection = dbConnection;
                try
                {
                    numRowsAffected = sQLiteCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    dbConnection.Close();
                    return false;
                }
                dbConnection.Close();
            }
            if (numRowsAffected <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Employee FetchEmployee(int empId)
        {
            Employee employee = new Employee();
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "SELECT zid, ime, prezime, korime, adresa, lozinka, oid," +
                    " bankovniRacun, email FROM zaposlenik as z WHERE zid = @empId";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);
                sQLiteCommand.Parameters.AddWithValue("@empId", empId);
                sQLiteCommand.Connection = dbConnection;

                using (sQLiteCommand)
                {
                    using (IDataReader reader = sQLiteCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employee.Id = reader.GetInt32(0);
                            employee.FirstName = reader.GetString(1);
                            employee.LastName = reader.GetString(2);
                            employee.Username = reader.GetString(3);
                            employee.Address = reader.GetString(4);
                            employee.Password = reader.GetString(5);
                            employee.DepId = reader.GetInt32(6);
                            employee.BankAcc = reader.GetString(7);
                            employee.Email = reader.GetString(8);
                        }
                        reader.Close();
                        dbConnection.Close();
                    }
                }
            }
            return employee;
        }

        public static bool SetEmployeePass(int empId, string pass)
        {
            int numRowsAffected = 0;
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "UPDATE zaposlenik SET lozinka = @pass WHERE zid = @empId";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);

                sQLiteCommand.Parameters.AddWithValue("@pass", pass);
                sQLiteCommand.Parameters.AddWithValue("@empId", empId);
                sQLiteCommand.Connection = dbConnection;
                try
                {
                    numRowsAffected = sQLiteCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    dbConnection.Close();
                    return false;
                }
                dbConnection.Close();
            }
            if (numRowsAffected <= 0)
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
