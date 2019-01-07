using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigurnost_SQLite_BP
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Manager { get; set; }

        public Department(int id, string name, int manager)
        {
            Id = id;
            Name = name;
            Manager = manager;
        }

        public Department(int id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}
