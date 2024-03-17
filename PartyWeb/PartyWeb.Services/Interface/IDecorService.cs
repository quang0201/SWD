using ModelViews.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IDecorService
    {
        public Task<bool> AddDecor(DecorModel Decor, string user);
        public Task<bool> Update(UpdateDecorModel food, string user);
        public Task<bool> Delete(int id, string user);

    }
}
