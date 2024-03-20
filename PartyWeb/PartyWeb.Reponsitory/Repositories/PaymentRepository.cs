using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task<bool> Add(Payment payment) => PaymenDAO.Instance.Add(payment);

        public Task<int> GetTotalPayment() => PaymenDAO.Instance.GetTotalPayment();
    }
}
