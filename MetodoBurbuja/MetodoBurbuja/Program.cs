using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoBurbuja
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] vector = new int[8] { 
                6,5,3,1,8,7,2,4            
            };

            int t;
            for (int a = 1; a < vector.Length; a++)
            { 
                for (int b = vector.Length - 1; b >= a; b--)
                {
                    if (vector[b - 1] > vector[b])
                    {
                        t = vector[b - 1];
                        vector[b - 1] = vector[b];
                        vector[b] = t;
                    }
                }
            }

            
            for (int f = 0; f < vector.Length; f++)
            {
                Console.Write(vector[f] + "  ");
            }
            Console.ReadKey();


        }
    }
}
