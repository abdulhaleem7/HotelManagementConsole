using SecondProject.Repository;
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
            
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"+WELCOME TO++++{Person.NameofHotel}");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine();
            ManagerRepository manager = new ManagerRepository();
            CustomerRepository customer = new CustomerRepository();
            RoomRepository room = new RoomRepository();
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("1.For manager registration \n" 
                    + "2.For ROOM CREATION \n"
                    + "3.FOR CUTOMER BOOKING\n" 
                   + "4.FOR CHECK OUT\n"
                    + "5.FOR LIST OF ALL REGISTERED CUSTOMER\n"
                    + "6.MANAGER DETAILS\n" +
                    "7.sacked manager\n" +
                    "8.AVAILABLE ROOM:\n " +
                    "9.BREAK .....");
                
                int respond = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (respond == 1)
                {
                    manager.RegisterManager();
                    
                }
                else if (respond == 2)
                {

                    room.RegisterRoom();
                   
                }
                else if (respond == 3)
                {

                    customer.RegisterCustomer();

                }
                else if (respond == 4)
                {
                    room.CheckOut();
                   
                }
                else if (respond == 5)
                {

                    customer.PrintCustomerDetails();
                }
                else if (respond == 6)
                {
                    manager.PrintManagerDetail();
                }
                else if (respond == 7)
                {
                    manager.SackManager();
                }
                else if (respond == 8)
                {
                    room.AvailableRooms();
                }
                else if (respond == 9)
                {
                    Console.WriteLine("THANKS FOR USING OUR HOTEL!!");
                    break;
                }
            }
            
        }
    

    }

}
