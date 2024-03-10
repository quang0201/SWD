﻿using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<bool> Add(Order order) => OrderDAO.Instance.Add(order);
    }
}
