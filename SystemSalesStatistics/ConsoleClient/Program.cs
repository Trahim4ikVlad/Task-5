using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();

            foreach (var order in worker.GetAllOrders())
            {
                Console.Write(order.ClientName);
            }

        }
    }
}
