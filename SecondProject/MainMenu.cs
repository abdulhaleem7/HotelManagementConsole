using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    class MainMenu
    {
      public static void menu()
      {
            Hotel();
      }
        public static void Hotel()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"+WELCOME TO++++{Person.NameofHotel}");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("++++++++++++for manager registration press 1++++++++++++++++++\n" 
                    + "+++++++++++++for ROOM CREATION press 2++++++++++++++++++++\n"
                    + "+++++++++++++FOR CUTOMER BOOKING PRESS 3++++++++++++++++++\n" + 
                    "+++++++++++++++FOR CHECK OUT PRESS 4++++++++++++++++++++++\n"
                    + "+++++++++++++FOR LIST OF ALL REGISTERED CUSTOMER PRESS 5++++++++++++\n"
                    + "+++++++++++++++++++PRESS 6 TO BREAK+++++++++++++++++++++++");
                Console.ForegroundColor = ConsoleColor.White;
                int respond = int.Parse(Console.ReadLine());
                
                if (respond == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
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
                    Console.ForegroundColor = ConsoleColor.White;
                    if (age < 18)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("WE CANT REGISTER YOU DUE TO YOUR AGE ....THANKS A LOT");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Manager manager = new Manager(firstname, lastname, middlename, phonenumber, age, address);
                        Manager.managers.Add(manager);
                        manager.PrintManagerID();
                        continue;
                    }


                    Console.WriteLine();
                }
                else if (respond == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("GENERATING ROOM ONLY BY MANAGER:+++++");
                    Console.WriteLine("ENTER MANAGER ID");
                    Console.ForegroundColor = ConsoleColor.White;
                    var id = Console.ReadLine();

                    foreach (var manager in Manager.managers)
                    {
                        if (id == manager.ManagerID)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("creation of rooms");
                            Console.Write("ENTER ROOM TYPE: ");
                            var roomstandard = Console.ReadLine();
                            Console.Write("ENTER PRICE: ");
                            int price = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.White;
                            Rooms roomses = new Rooms(price, roomstandard);
                            Rooms.room.Add(roomses);
                            Rooms.AvailableRooms();
                        }
                        else if (id != manager.ManagerID)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("SORRY YOU ARE NOT ALLOW TO CREATE ANY ROOM");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.WriteLine();
                }
                else if (respond == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("MANAGER ATTENTION PLS ;SOMEONE IS TRYING TO ACCESS OUR WEBSITE;VERIFY THE APP FOR THE CUSTOMER PLS :");
                    Console.ForegroundColor = ConsoleColor.White;

                    var id = Console.ReadLine();

                    foreach (var manager in Manager.managers)
                    {
                        if (id == manager.ManagerID)
                        {
                            Rooms.AvailableRooms();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("CHOOSE ROOM NUMBER : ");
                            var roomnumber = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;

                            foreach (var item in Rooms.room)
                            {
                                while (item.IsAvailable)
                                {
                                    if (roomnumber == item.RoomNumber)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
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
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Customer customer = new Customer(firstname, lastname, middlename, phonenumber, age, address);
                                        Customer.customers.Add(customer);
                                        customer.PrintCustomerID();
                                        Rooms.UpDateRoomAvailability(roomnumber, false);
                                        break;
                                    }
                                    else if(roomnumber!=item.RoomNumber)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("No available room");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        break;
                                    }

                                }

                            }



                        }
                        else if (id != manager.ManagerID)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry only manager ia allow to register you!!!!!!!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                }
                else if (respond == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("MANAGER ATTENTION PLS ;SOMEONE IS TRYING TO CHECK OUT;VERIFY THE APP FOR THE CUSTOMER PLS :");
                    Console.ForegroundColor = ConsoleColor.White;
                    var id = Console.ReadLine();

                    foreach (var manager in Manager.managers)
                    {
                        if (id == manager.ManagerID)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("ENTER YOUR ROOM NUMBER ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            var roomnumber = Console.ReadLine();
                            Rooms.UpDateRoomAvailability(roomnumber, true);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"THANKS FOR USING {Person.NameofHotel}");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("MANAGER MUST VERIFY YOUR ROOM NUMBER FOR CHECKING OUT!!!!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                else if (respond == 5)
                {
                    Customer.PrintCustomerDetails();

                }
                else if (respond == 6)
                {
                    break;
                }
            }
            
        }
    

    }

}
