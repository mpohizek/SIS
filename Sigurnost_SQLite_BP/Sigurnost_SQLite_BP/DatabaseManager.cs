﻿using System;
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
        internal static bool CheckUser(string username, string password)
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

        internal static bool AddDepartment(Department department)
        {
            int numRowsAffected = 0;
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "INSERT INTO odjel values (@id, @name, null)";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);

                sQLiteCommand.Parameters.AddWithValue("@name", department.Name);
                sQLiteCommand.Parameters.AddWithValue("@id", department.Id);
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

        internal static bool AddEmployee(Employee employee)
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

        internal static bool SetDepManager(int depManager, int depId)
        {
            int numRowsAffected = 0;
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "UPDATE odjel SET upravitelj = @depManager WHERE oid = @depId";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);

                sQLiteCommand.Parameters.AddWithValue("@depManager", depManager);
                sQLiteCommand.Parameters.AddWithValue("@depId", depId);
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

        internal static Employee FetchEmployee(int empId)
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
                            //employee.Password = reader.GetString(5);
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
        internal static Employee FetchEmployee(string username)
        {
            Employee employee = new Employee();
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "SELECT zid, ime, prezime, korime, adresa, lozinka, oid," +
                    " bankovniRacun, email FROM zaposlenik as z WHERE korime = @username";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);
                sQLiteCommand.Parameters.AddWithValue("@username", username);
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

        internal static int FetchManagerDepId(string username)
        {
            int depId = 0;
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "SELECT o.oid FROM zaposlenik as z JOIN odjel as o ON o.upravitelj = z.zid WHERE z.korime = @username";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);
                sQLiteCommand.Parameters.AddWithValue("@username", username);
                sQLiteCommand.Connection = dbConnection;

                using (sQLiteCommand)
                {
                    using (IDataReader reader = sQLiteCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            depId = reader.GetInt32(0);
                        }
                        reader.Close();
                        dbConnection.Close();
                    }
                }
            }
            return depId;
        }


        internal static bool SetEmployeePass(int empId, string pass)
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
        internal static bool SetEmployeePass(string korime, string pass)
        {
            int numRowsAffected = 0;
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "UPDATE zaposlenik SET lozinka = @pass WHERE korime = @username";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);

                sQLiteCommand.Parameters.AddWithValue("@pass", pass);
                sQLiteCommand.Parameters.AddWithValue("@username", korime);
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

        internal static List<Employee> GetMyEmployees(string korime, string pass)
        {
            List<Employee> employees = new List<Employee>();
            using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                string sqlQuery = "SELECT zid, ime, prezime, korime, adresa, lozinka, oid, bankovniRacun, email " +
                    "FROM zaposlenik as z WHERE oid = (SELECT o.oid FROM zaposlenik as z JOIN odjel as o ON o.upravitelj = z.zid WHERE z.korime = @username)";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlQuery);
                sQLiteCommand.Parameters.AddWithValue("@username", korime);
                sQLiteCommand.Connection = dbConnection;

                using (sQLiteCommand)
                {
                    using (IDataReader reader = sQLiteCommand.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Id = reader.GetInt32(0);
                            employee.FirstName = reader.GetString(1);
                            employee.LastName = reader.GetString(2);
                            employee.Username = reader.GetString(3);
                            employee.Address = reader.GetString(4);
                            //employee.Password = reader.GetString(5);
                            employee.DepId = reader.GetInt32(6);
                            employee.BankAcc = reader.GetString(7);
                            employee.Email = reader.GetString(8);

                            employees.Add(employee.Decrypt(pass));
                        }
                        reader.Close();
                        dbConnection.Close();
                    }
                }
            }
            return employees;
        }

    }
}
