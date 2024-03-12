using ModelViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.ModelView
{
    public class UpdateRoomModel
    {
        public int Id { get; set; } = default!;
        public RoomModel Room { get; set; } = default!;
    }
}
