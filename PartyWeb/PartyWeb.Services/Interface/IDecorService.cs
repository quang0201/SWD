using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using ModelViews;

namespace Services.Interface
{
    public interface IDecorService
    {
        public Task<Tuple<string, bool>> AddDecor(DecorModel food, Account account);

    }
}
