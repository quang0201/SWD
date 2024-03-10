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

    }
}
