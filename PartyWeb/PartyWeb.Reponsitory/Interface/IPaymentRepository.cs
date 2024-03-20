﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Interface
{
    public interface IPaymentRepository
    {
        public Task<bool> Add(Payment payment);
        public Task<int> GetTotalPayment();
    }
}
