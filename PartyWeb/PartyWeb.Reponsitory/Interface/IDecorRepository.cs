using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IDecorRepository
    {
        Task<bool> Add(Decor decor);

    }
}
