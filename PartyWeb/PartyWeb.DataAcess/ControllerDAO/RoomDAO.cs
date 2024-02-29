using BusinessObjects.Models;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.ControllerDAO
{
    public class RoomDAO
    {
        public static List<Room> GetRooms()
        {
            var Rooms = new List<Room>();
            try
            {
                using (var context = new SwdContext())
                {
                    Rooms = context.Rooms.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Rooms;

        }

        public static Room GetRoomsById(int id)
        {
            var Rooms = new Room();
            try
            {
                using (var context = new SwdContext())
                {
                    Rooms = context.Rooms
                    .SingleOrDefault(c => c.Int == id);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Rooms;

        }

        public static void CreateRooms(Room d)
        {
            try
            {
                using (var context = new SwdContext())
                {
                    context.Rooms.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void UpdateRooms(Room d)
        {
            try
            {
                using (var context = new SwdContext())
                {
                    context.Entry<Room>(d).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void DeleteRooms(int RoomId)
        {
            try
            {
                using (var context = new SwdContext())
                {

                    var RoomToDelete = context.Rooms
                    .SingleOrDefault(c => c.Int == RoomId);
                    RoomToDelete.Status = 0;
                    context.Entry<Room>(RoomToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
