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
       
       
        
        
      
       
        public Manager(string firstname, string lastName, string middleName, string phonenumber, int age, string address) : base(firstname, lastName, middleName, phonenumber, age, address)
        {
            ManagerID = GenerateManagerID();
            

        }
        public Manager(string firstname, string lastName, string middleName, string phonenumber, int age, string address, string id) : base(firstname, lastName, middleName, phonenumber, age, address)
        {
            ManagerID = id;


        }
        public void PrintManagerID()
        {
           
            Console.WriteLine($"DEAR {Firstname}WELCOME TO {Person.NameofHotel} AS MANAGER.YOUR PIN IS {ManagerID}");
            
        }
        public override string ToString()
        {
            return $"{ManagerID}\t{Firstname}\t{LastName}\t{MiddleName}\t{Phonenumber}\t{Age}\t{Address}";
        }
        public static Manager ToManager(string student)
        {
            var manager1 = student.Split("\t");
            string id = manager1[0];
            string firstName = manager1[1];
            string lastname = manager1[2];
            var middlename = manager1[3];
            var phonenumber = manager1[4];
            var age = int.Parse(manager1[5]);
            var adderess = manager1[6];

            return new Manager(firstName, lastname, middlename, phonenumber, age, adderess,id);
        }



        private static string GenerateManagerID()
        {
            Random rand = new Random();
            return $"{rand.Next(10, 30).ToString("MNGR00")}";
        }
       



    }
}
