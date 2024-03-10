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

    }
}
