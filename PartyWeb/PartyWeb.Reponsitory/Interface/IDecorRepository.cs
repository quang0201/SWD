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
        Task<bool> Update(Decor room);

        Task<Decor> GetById(int id);
        Task<List<Decor>> PaggingDecor(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc);
    }
}
