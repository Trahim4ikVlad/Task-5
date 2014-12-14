using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ClientName { get; set; }
        public string  ManagerName { get; set; }
        public double Cost { get; set; }
        public string ProductName { get; set; }
    }
}
