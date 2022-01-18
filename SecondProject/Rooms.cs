using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public class Rooms
    {

        public int RoomPrice { get; set; }
        public string RoomStandard { set; get; }
        public static string RoomID { set; get; }
        public bool IsAvailable { get; set; } 
        public string  RoomNumber { get; set; }
        
        
        public static List<Rooms> room = new List<Rooms>();

        public Rooms(int roomprice,string roomstandard)
        {
            RoomPrice = roomprice;
            RoomStandard = roomstandard;
            RoomNumber = GenerateRoomNumber();
            IsAvailable = true;
        }
        private string GenerateRoomNumber()
        {
            Random rand = new Random();
            return $"{ rand.Next(1,10).ToString("0001")}";
        }
        public static void UpDateRoomAvailability(string roomNum, bool status)
        {
            foreach (var rm in room)
            {
                if (rm.RoomNumber.Equals(roomNum))
                {
                   
                    rm.IsAvailable = status;
                   
                }
            }
        }
        
        public static void AvailableRooms()
        {
            for (int i = 0; i < room.Count; i++)
            {
                if (room[i].IsAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{i + 1}.{room[i].RoomNumber}.{room[i].RoomStandard}...{room[i].RoomPrice}");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
        }
       
    }
}
