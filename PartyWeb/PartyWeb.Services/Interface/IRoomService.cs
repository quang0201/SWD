using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using ModelViews;

namespace Services.Interface
{
    public interface IRoomService
    {
        public Task<Tuple<string, bool>> AddRoom(RoomModel room, Account account);

    }
}
