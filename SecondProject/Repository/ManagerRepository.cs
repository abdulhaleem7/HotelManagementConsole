using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject.Repository
{
    public class ManagerRepository
    {
        string file = "C:\\Users\\user\\source\\repos\\SecondProject\\SecondProject\\Manager.txt";
        public  List<Manager> managers = new List<Manager>();
        
        public ManagerRepository()
        {
            
            ReadManagerFromFile();
        }
        public void ReadManagerFromFile()
        {
            try{
                if (File.Exists(file))
                {
                    var allmanager = File.ReadAllLines(file);
                    foreach (var mang in allmanager)
                    {
                        managers.Add(Manager.ToManager(mang));
                    }
                }
                else
                {
                    string path = "C:\\Users\\user\\source\\repos\\SecondProject";
                    Directory.CreateDirectory(path);
                    string filename = "SecondProject";
                    string filepath = Path.Combine(path, filename);
                    File.Create(file);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void AddManager(Manager manager)
        {
            using (StreamWriter write = new StreamWriter(file, true))
            {
                write.WriteLine(manager.ToString());
            }
        }
        private void RefreshManagerfile()
        {
            using (StreamWriter write = new StreamWriter(file))
            {
                foreach (var manager in managers)
                {
                    write.WriteLine(manager.ToString());
                }
            }
        }
        public  void PrintManagerDetail()
        {
            for (int i = 0; i < managers.Count; i++)
            {            
                Console.WriteLine($"{i + 1}..{managers[i].Firstname}..{managers[i].LastName}..{managers[i].ManagerID}");
               
            }
        }
        public void RegisterManager()
        {
            Console.Write("ENTER YOUR FIRST NAME: ");
            var firstname = Console.ReadLine();
            Console.Write("ENTER YOUR LAST NAME: ");
            var lastname = Console.ReadLine();
            Console.Write("ENTER YOUR MIDDLE NAME: ");
            var middlename = Console.ReadLine();
            Console.Write("ENTER YOUR PHONE NUMBER: ");
            var phonenumber = Console.ReadLine();
            Console.Write("ENTER YOUR AGE: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("ENTER YOUR ADDRESS: ");
            var address = Console.ReadLine();
            if (age < 18)
            {
                Console.WriteLine("WE CANT REGISTER YOU DUE TO YOUR AGE ....THANKS A LOT");
            }
            else
            {
                Manager manager = new Manager(firstname, lastname, middlename, phonenumber, age, address);
                managers.Add(manager);
                manager.PrintManagerID();
                AddManager(manager);
            }
        }

        public void SackManager()
        {
            
            if (managers.Count ==1)
            {
                Console.WriteLine("ONE MANAGER MUST BE AVAILABLE B4 SACKING ANY MANAGER!!!");
               
            }
            else
            {
                PrintManagerDetail();
                Console.Write("Enter id of MANAGER to delete");
                var id = Console.ReadLine();
                foreach (var managerr in managers)
                {
                    if (id == managerr.ManagerID)
                    {
                        managers.Remove(managerr);
                        RefreshManagerfile();
                        Console.WriteLine($"manager with id:{id} was successfully sacked...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"manager with {id} does not exist..");
                    }
                }
            }
           

        }
    }
}
