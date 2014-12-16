 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using BusinessLayer.DTOEntity;
 using DataAccessLayer;

namespace BusinessLayer.Mappers
{
    public class ClientMapper:MapperBase<Client, ClientDto>
    {
       
        public ClientMapper()
        {
            
        }

        public override Client Map(ClientDto element)
        {
            return new Client()
            {
                Name = element.Name
            };
        }

        public override ClientDto Map(Client element)
        {
            return new ClientDto()
            {
                Id = element.ID,
                Name = element.Name
            };
        }
    }
}
