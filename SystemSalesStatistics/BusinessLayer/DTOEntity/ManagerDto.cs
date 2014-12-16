using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer.DTOEntity
{
    public class ManagerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderDto> Orders { get; set; }
    }
}
