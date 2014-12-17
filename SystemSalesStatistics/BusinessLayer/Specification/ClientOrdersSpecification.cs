﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;

namespace BusinessLayer.Specification
{
    public class ClientOrdersSpecification:IOrderSpecification
    {
        private readonly string _clientName;

        public ClientOrdersSpecification(string clientName)
        {
            _clientName = clientName;
        }

        public IEnumerable<OrderDto> SatisfiedBy(IEnumerable<OrderDto> orders)
        {
            return _clientName!=null ? orders.Where(x => x.Client.Name == _clientName) : orders;
        }
    }
}
