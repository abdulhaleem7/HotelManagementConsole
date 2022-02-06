using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    
    public class Customer : Person
    {
        public string CustomerID { get; }
        
        
        
        
        public Customer(string firstname, string lastName, string middleName,string phonenumber, int age, string address) : base(firstname, lastName, middleName, phonenumber, age, address)
        {
            CustomerID = GenerateID();
           
        }
        public Customer(string firstname, string lastName, string middleName, string phonenumber, int age, string address,string id) : base(firstname, lastName, middleName, phonenumber, age, address)
        {
            CustomerID = id;

        }
        public void PrintCustomerID()
        {
            
            Console.WriteLine($"Dear {Firstname}..{LastName} welcome to {Person.NameofHotel}...your CUSTOMER ID IS {CustomerID}");
            
        }
        private string GenerateID()
        {
            Random rand = new Random();
            return $"{rand.Next(20, 40).ToString("1020000")}";
        }
        public override string ToString()
        {
            return $"{CustomerID}\t{Firstname}\t{LastName}\t{MiddleName}\t{Phonenumber}\t{Age}\t{Address}";
        }
        public static Customer ToCustomer(string student)
        {
            var customer1 = student.Split("\t");
            string id = customer1[0];
            string firstName = customer1[1];
            string lastname = customer1[2];
            var middlename = customer1[3];
            var phonenumber = customer1[4];
            var age =int.Parse( customer1[5]);
            var adderess = customer1[6];

            return new Customer(firstName,lastname,middlename,phonenumber,age,adderess,id);
        }

    }
}
