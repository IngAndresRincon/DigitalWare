using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {

            int fac = 10; 
            int total = 1;
            for (int i = 1; i <= fac; i++)
            {
                total *= i;
            }
            Console.WriteLine(total);
            Console.ReadKey();
            
        }
    }
}
