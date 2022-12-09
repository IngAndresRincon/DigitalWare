using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[] { 1, 8, 6, 7, 2, 5 };

            try
            {
                foreach (int i in myArray)
                {                     
                    for(int j= 1; j<myArray.Length;j++)
                    {
                        if ((i + myArray[j]) == 10)
                        {
                            Console.WriteLine(i + " " + myArray[j]);
                            Console.ReadLine();
                            return;
                        }
                    }
                }

                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
