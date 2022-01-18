using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public class Manager : Person
    {
        public string ManagerID { get; set; }
       
       
        
        public static List<Manager> managers = new List<Manager>();
      
       
        public Manager(string firstname, string lastName, string middleName, string phonenumber, int age, string address) : base(firstname, lastName, middleName, phonenumber, age, address)
        {
            ManagerID = GenerateManagerID();
            

        }
        public void PrintManagerID()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"DEAR {Firstname}WELCOME TO {Person.NameofHotel} AS MANAGER.YOUR PIN IS {ManagerID}");
            Console.ForegroundColor = ConsoleColor.White;
        }
      
	
       
        private static string GenerateManagerID()
        {
            Random rand = new Random();
            return $"{rand.Next(10, 30).ToString("MNGR00")}";
        }
        public static void PrintManagerDetail()
        {
            for (int i = 0; i < managers.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{i+1}..{managers[i].Firstname}..{managers[i].LastName}..{managers[i].ManagerID}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }



    }
}
