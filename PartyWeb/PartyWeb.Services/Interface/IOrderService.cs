using BusinessObjects.Models;
using ModelViews.Models;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IOrderService
    {
        public Task<CreatePaymentResult> Add(OrderModel model,string user);

    }
}
