﻿using Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Order.Interfaces
{
    public interface IOrderServiceAplication
    {
        Task CreateNewOrder(CreteNewOrderDTO orderDTO);
    }
}