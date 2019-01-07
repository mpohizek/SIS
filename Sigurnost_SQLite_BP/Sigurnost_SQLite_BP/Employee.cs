using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigurnost_SQLite_BP
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int DepId { get; set; }
        public string BankAcc { get; set; }
        public string Email { get; set; }

        public Employee(int id, string firstName, string lastName, string username, string address, string password, int depId, string bankAcc, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Address = address;
            Password = password;
            DepId = depId;
            BankAcc = bankAcc;
            Email = email;
        }

        public Employee(string firstName, string lastName, string username, string address, int depId, string bankAcc, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Address = address;
            DepId = depId;
            BankAcc = bankAcc;
            Email = email;
        }

        public Employee()
        {
        }
    }
}
