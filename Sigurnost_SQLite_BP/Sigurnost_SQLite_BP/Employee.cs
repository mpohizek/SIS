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

        public Employee Encrypt(string pass)
        {
            this.FirstName = Encryption.Encrypt(this.FirstName, pass);
            this.LastName = Encryption.Encrypt(this.LastName, pass);
            //this.Username = Encryption.Encrypt(this.Username, pass);
            this.Address = Encryption.Encrypt(this.Address, pass);
            this.BankAcc = Encryption.Encrypt(this.BankAcc, pass);
            this.Email = Encryption.Encrypt(this.Email, pass);
            return this;
        }
        public override string ToString()
        {
            return DepId + " | " + FirstName + " " + LastName + " " + Username + " " + Address + " " + BankAcc + " " + Email;
        }

        internal Employee Decrypt(string pass)
        {
            this.FirstName = Encryption.Decrypt(this.FirstName, pass);
            this.LastName = Encryption.Decrypt(this.LastName, pass);
            //this.Username = Encryption.Decrypt(this.Username, pass);
            this.Address = Encryption.Decrypt(this.Address, pass);
            this.BankAcc = Encryption.Decrypt(this.BankAcc, pass);
            this.Email = Encryption.Decrypt(this.Email, pass);
            return this;
        }
    }
}
