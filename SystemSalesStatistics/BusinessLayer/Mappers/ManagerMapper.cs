using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;
using DataAccessLayer;

namespace BusinessLayer.Mappers
{
    public class ManagerMapper:MapperBase<Manager, ManagerDto>
    {
        //private OrderMapper _mapper = new OrderMapper();

        public ManagerMapper()
        {
        }

        public override Manager Map(ManagerDto element)
        {
            return new Manager()
            {
                Name = element.Name
            };
        }

        public override ManagerDto Map(Manager element)
        {
            return new ManagerDto()
            {
                ID = element.ID,
                Name = element.Name
            };
        }
    }
}
