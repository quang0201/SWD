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
    public class DecorRepository : IDecorRepository
    {
        public async Task<bool> Add(Decor decor) => await DecorDAO.Instance.Add(decor);
        public async Task<bool> Update(Decor decor) => await DecorDAO.Instance.Update(decor);

        public Task<Decor> GetById(int id) => DecorDAO.Instance.GetById(id);

        public Task<List<Decor>> PaggingDecor(int index, int pageSize, string? search, bool? sortDateAsc, bool? sortPriceAsc, bool? sortNameAsc)
        {
            return DecorDAO.Instance.PaggingDecor(index,pageSize,search,sortDateAsc,sortPriceAsc,sortNameAsc);
        }
    }
}
