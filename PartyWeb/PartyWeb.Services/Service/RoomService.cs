using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class RoomService : IRoomService
    {
        public void CreateRooms(Room d)
        => RoomDAO.CreateRooms(d);

        public void DeleteRooms(int RoomId)
        => RoomDAO.DeleteRooms(RoomId);

        public List<Room> GetRooms()
        => RoomDAO.GetRooms();

        public Room GetRoomsById(int RoomId)
        => RoomDAO.GetRoomsById(RoomId);

        public void UpdateRooms(Room d)
        => RoomDAO.UpdateRooms(d);
    }
}
