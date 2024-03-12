using Reponsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAcess.ControllerDAO;

namespace Reponsitories.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public async Task<bool> Add(Room room) => await RoomDAO.Instance.Add(room);
        public async Task<bool> Update(Room room) => await RoomDAO.Instance.Update(room);

        public Task<Room> GetById(int id) => RoomDAO.Instance.GetById(id);
    }
}
