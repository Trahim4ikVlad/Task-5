using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.DTOEntity;
using BusinessLayer.Mappers;
using DataAccessLayer;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            Client client = new Client()
            {
                ID = 1,
                Name = "Retut"
            };

            ClientMapper clientMapper = new ClientMapper();

            ClientDto clientDto = clientMapper.Map(client);

            foreach (var order in worker.GetAllOrders())
            {
                Console.WriteLine(order.Id + " " + order.Client.Name + " " + order.Cost);
            }
            Console.WriteLine(clientDto.Id + " " + clientDto.Name);

        }
    }
}
