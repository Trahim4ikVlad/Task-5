using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer.DTOEntity
{
    public class OrderDto
    {
        public int Id { get; set; }
        
        public System.DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public double Cost { get; set; }

        public  ClientDto Client { get; set; }
        public  ManagerDto Manager { get; set; }
    }
}
