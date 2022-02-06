using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public class Rooms
    {
        
        public string RoomPrice { get; set; }
        public string RoomStandard { set; get; }
        public  string RoomID { set; get; }
        public bool IsAvailable { get; set; } 
        public string  RoomNumber { get; set; }
               
        public Rooms(string roomprice, string roomstandard,string roomid,string roomnumber)
        {
            RoomPrice = roomprice;
            RoomStandard = roomstandard;
            RoomNumber = roomnumber;
            RoomID = roomid;
            IsAvailable = true;
        }
        public Rooms(string roomprice,string roomstandard)
        {
            RoomPrice = roomprice;
            RoomStandard = roomstandard;
            RoomNumber = GenerateRoomNumber();           
            IsAvailable = true;
        }
        public override string ToString()
        {
            return $"{RoomID}\t{RoomNumber}\t{RoomPrice}\t{RoomStandard}";
        }
        public static Rooms ToRoom(string room)
        {
            var room1 = room.Split("\t");
            string roomid = room1[0];
            string rooomnumber = room1[1];
            string roomprice = room1[2];
            var roomstandard = room1[3];
            return new Rooms(roomprice,roomstandard,roomid,rooomnumber);
        }
        private string GenerateRoomNumber()
        {
            Random rand = new Random();
            return $"{ rand.Next(1,10).ToString("0001")}";
        }       
    }
}
