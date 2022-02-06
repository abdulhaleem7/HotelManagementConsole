using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public abstract class Person
    {
        public const string NameofHotel = "PATIENCE HOTEL AND SUITE";
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phonenumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Person(string firstname, string lastName, string middleName, string phonenumber, int age, string address)
        {
            Firstname = firstname;
            LastName = lastName;
            MiddleName = middleName;
            Phonenumber = phonenumber;
            Age = age;
            Address = address;
        }

        protected Person()
        {

        }

       
    }
}
