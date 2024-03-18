using BusinessObjects.Models;
using ModelViews.Models;
using ModelViews.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IRoomService
    {
        public Task<bool> AddRoom(RoomModel Room, string user);
        public Task<bool> Update(UpdateRoomModel food, string user);
        public Task<List<RoomViewModel>> PaggingRoom(int index, int pageSize, string? search, bool? sortDate, bool? sortPrice, bool? sortName);

        public Task<bool> Delete(int id, string user);
        public Task<Room> Approve(int id, string user);

    }
}
