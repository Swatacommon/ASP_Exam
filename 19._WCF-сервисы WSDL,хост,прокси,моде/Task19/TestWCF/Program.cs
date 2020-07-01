using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWCF.WCFService;

namespace TestWCF
{
    class Program
    {
        private static IService1 Service { get; set; }
        static void Main(string[] args)
        {
            Service = new Service1Client();
            var phones = Service.GetDict();
            foreach(var item in phones)
            {
                Console.WriteLine($"Имя {item.Name} | Номер Телефона {item.Phone_Number}");
            }
        }
    }
}
