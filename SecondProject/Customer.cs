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
        
        
        public static List<Customer> customers = new List<Customer>();
        
        public Customer(string firstname, string lastName, string middleName,string phonenumber, int age, string address) : base(firstname, lastName, middleName, phonenumber, age, address)
        {
            CustomerID = GenerateID();
           
        }
        public void PrintCustomerID()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Dear {Firstname}..{LastName} welcome to {Person.NameofHotel}...your CUSTOMER ID IS {CustomerID}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private string GenerateID()
        {
            Random rand = new Random();
            return $"{rand.Next(20, 40).ToString("1020000")}";
        }
        public static void PrintCustomerDetails()
        {
            for (int i = 0; i < customers.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{i+1}..{customers[i].Firstname}....{customers[i].LastName}...{customers[i].CustomerID}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        
    }
}
