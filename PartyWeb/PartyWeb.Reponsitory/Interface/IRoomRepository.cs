using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IRoomRepository
    {
        Task<bool> Add(Room room);
        Task<Room> GetById(int id);
        Task<bool> Update(Room room);
        Task<List<Room>> PaggingRoom(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc);
    }
}
