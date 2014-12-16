using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class OrderViewModel
    {
        public DateTime OrderDate { get; set; }
        public string ClientName { get; set; }
        public string  ManagerName { get; set; }
        public double Cost { get; set; }
        public string ProductName { get; set; }
    }
}
