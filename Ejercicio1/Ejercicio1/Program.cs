using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArrya = new int[5];

            //Crear el array
            for (int i = 0; i < 5; i++)
            {
                var numrandom = new Random().Next(0, 100);
                Thread.Sleep(300);
                myArrya[i] = numrandom;
            }

            //Imprimir el array
            foreach (int i in myArrya)
            {
                Console.Write(i.ToString()+",");
            }


            int numMayor = 0;

            foreach (int j in myArrya)
            {
                if (j > numMayor)
                {
                    numMayor = j;
                }
            }

            Console.WriteLine("\n"+numMayor);
            Console.ReadKey();
        }
    }
}
