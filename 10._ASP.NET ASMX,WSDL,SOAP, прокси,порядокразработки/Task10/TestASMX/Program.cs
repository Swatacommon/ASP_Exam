using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestASMX.AsmxService;

namespace TestASMX
{
    class Program
    {
        private static WebService1SoapClient Service { get; set; }
        static void Main(string[] args)
        {
            Service = new WebService1SoapClient();
            Console.WriteLine(Service.HelloWorld());
            Console.WriteLine(Service.Sum(1,7));
        }
    }
}
