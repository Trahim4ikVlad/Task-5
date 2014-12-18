using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.DTOEntity;
using BusinessLayer.Mappers;
using BusinessLayer.Specification;
using DataAccessLayer;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorker worker = new Worker();

           var orderDto =  worker.Search(new SearchSpecification()
            {
                ClientName = "Sososcin",
            });

            Console.WriteLine("fsfs");

            if (orderDto != null)
            {
                //orderDto.Client.Name = "TETYTO";

               // worker.Update(orderDto);
            }
            

        }
    }
}
