using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject.Repository
{
    public class RoomRepository
    {
        string file = "C:\\Users\\user\\source\\repos\\SecondProject\\SecondProject\\Room.txt";
        public  List<Rooms> rooms = new List<Rooms>();
        ManagerRepository manage = new ManagerRepository();
        
        public RoomRepository()
        {
           
            
            ReadRoomFromFile();
        }
        public void ReadRoomFromFile()
        {
            if (File.Exists(file))
            {
                var allrooms = File.ReadAllLines(file);
                foreach (var r in allrooms)
                {
                    rooms.Add(Rooms.ToRoom(r));
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
        private void AddRoomToFile(Rooms room)
        {
            using (StreamWriter write = new StreamWriter(file, true))
            {
                write.WriteLine(room.ToString());
            }
        }
        private void RefreshRoomfile()
        {
            using (StreamWriter write = new StreamWriter(file))
            {
                foreach (var room in rooms)
                {
                    write.WriteLine(room.ToString());
                }
            }

        }
        public  void UpDateRoomAvailability(string roomNum, bool status)
        {
            foreach (var rm in rooms)
            {
                if (rm.RoomNumber.Equals(roomNum))
                {

                    rm.IsAvailable = status;

                }
            }
        }
        public  void AvailableRooms()
        {
            for (int i = 0; i < rooms.Count; i++)
            {

                if (rooms[i].IsAvailable)
                {
                    Console.WriteLine($"{i + 1}.{rooms[i].RoomNumber}.{rooms[i].RoomStandard}...{rooms[i].RoomPrice}");

                }
            }
        }
        public void RegisterRoom()
        {

       
                   
            if (manage.managers.Count== 0)
            {
                Console.WriteLine("MANAGER ISSUE PLS!!!");
            }
            else
            {
                Console.WriteLine("GENERATING ROOM ONLY BY MANAGER:+++++");
                Console.Write("ENTER MANAGER PIN: ");
                Console.WriteLine();

                var id = Console.ReadLine();
                foreach (var manager in manage.managers)
                {
                    if (id == manager.ManagerID)
                    {
                        if (rooms.Count > 0)
                        {
                            Console.WriteLine("creation of rooms");
                            Console.Write("ENTER ROOM TYPE: ");
                            var roomstandard = Console.ReadLine();
                            Console.Write("ENTER PRICE: ");
                            var price = Console.ReadLine();

                            Rooms roomses = new Rooms(price, roomstandard);
                            rooms.Add(roomses);
                            AvailableRooms();
                            AddRoomToFile(roomses);
                        }
                        else
                        {
                            Console.WriteLine("NO AVAILABLE ROOM!!");
                        }

                    }
                    else if (id != manager.ManagerID)
                    {

                        Console.WriteLine("SORRY YOU ARE NOT ALLOW TO CREATE ANY ROOM");

                    }
                }
                
            }
           
            
           
        }
        public void CheckOut()
        {
            if (manage.managers.Count == 0)
            {
                Console.WriteLine("MANAGER ISSUE PLS!!!");
               
            }
            else
            {
                Console.Write("MANAGER ATTENTION PLS ;SOMEONE IS TRYING TO CHECK OUT;VERIFY THE APP FOR THE CUSTOMER PLS :");

                var id = Console.ReadLine();

                foreach (var manager in manage.managers)
                {
                    if (id == manager.ManagerID)
                    {

                        Console.WriteLine("ENTER YOUR ROOM NUMBER ");

                        var roomnumber = Console.ReadLine();
                        UpDateRoomAvailability(roomnumber, true);
                        RefreshRoomfile();

                        Console.WriteLine($"THANKS FOR USING {Person.NameofHotel}");

                        break;
                    }
                    else
                    {

                        Console.WriteLine("MANAGER MUST VERIFY YOUR ROOM NUMBER FOR CHECKING OUT!!!!!!");

                    }
                }
            }
            
        }
        
    }
}
