using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject.Repository
{
    public class CustomerRepository
    {
        string file = "C:\\Users\\user\\source\\repos\\SecondProject\\SecondProject\\Customer.txt";
            public  List<Customer> customers = new List<Customer>();
        RoomRepository room = new RoomRepository();
        ManagerRepository managr= new ManagerRepository();
        public CustomerRepository()
        {           
            ReadCustomerFromFile();
           
        }
        public void ReadCustomerFromFile()
        {
            if (File.Exists(file))
            {
                var allcustomer = File.ReadAllLines(file);
                foreach (var cust in allcustomer)
                {
                    customers.Add(Customer.ToCustomer(cust));
                }               
            }
            else
            {
                string path = "C:\\Users\\user\\source\\repos\\SecondProject";
                Directory.CreateDirectory(path);
                string filename = "SecondProject\\File";
                string filepath = Path.Combine(path,filename);
                File.Create(file);
            }
        }
        private void AddCustomerToFile(Customer customer)
        {
            using(StreamWriter write=new StreamWriter(file, true))
            {
                write.WriteLine(customer.ToString());
            }
        }
        private void Refreshfile()
        {
            using (StreamWriter write = new StreamWriter(file))
            {
                foreach (var customer in customers)
                {
                    write.WriteLine(customer.ToString());
                }
            }            
        }
        public void PrintCustomerDetails()
        {
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"{i + 1}..{customers[i].Firstname}....{customers[i].LastName}...{customers[i].CustomerID}");
            }
        }
        public  void RegisterCustomer()
        {           
            if (managr.managers.Count== 0)
            {
                Console.WriteLine("BEER WITH US PLS !!MANAGER ISSUE PLS!!");                
            }
            else
            {
                Console.Write("MANAGER ATTENTION PLS ;SOMEONE IS TRYING TO ACCESS OUR WEBSITE;VERIFY THE APP FOR THE CUSTOMER PLS :");
                var id = Console.ReadLine();
                foreach (var manager in managr.managers)
                {
                    if (id == manager.ManagerID)
                    {
                        room.AvailableRooms();
                        Console.Write("CHOOSE ROOM NUMBER : ");
                        var roomnumber = Console.ReadLine();
                        foreach (var item in room.rooms)
                        {
                            if (item.IsAvailable)
                            {
                                if (roomnumber == item.RoomNumber)
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
                                    Console.Write("HOW MANY HOURS ARE YOU USING:");
                                    int hours = int.Parse(Console.ReadLine());

                                    Customer customer = new Customer(firstname, lastname, middlename, phonenumber, age, address);
                                    customers.Add(customer);
                                    AddCustomerToFile(customer);
                                    customer.PrintCustomerID();
                                    room.UpDateRoomAvailability(roomnumber, false);
                                }
                                else if (roomnumber != item.RoomNumber)
                                {
                                    Console.WriteLine("No available room");
                                }
                            }
                        }
                    }
                    else if (id != manager.ManagerID)
                    {
                        Console.WriteLine("Sorry only manager ia allow to register you!!!!!!!!!");
                    }
                }
            }            
        }
       
    }
}
