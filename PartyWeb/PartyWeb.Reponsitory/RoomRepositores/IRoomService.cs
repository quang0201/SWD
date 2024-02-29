using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.RoomRepositores
{
    public interface IRoomService
    {
        List<Room> GetRooms();
        Room GetRoomsById(int RoomId);
        void CreateRooms(Room d);

        void UpdateRooms(Room d);

        void DeleteRooms(int RoomId);
    }
}
