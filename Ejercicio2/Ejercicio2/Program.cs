using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[10];
            List<int> listnum = new List<int>();

            try
            {

                //Crear el array
                for (int i = 0; i < myArray.Length; i++)
                {
                    var numRandom = new Random().Next(1, 5);
                    Thread.Sleep(300);
                    myArray[i] = numRandom;
                }

                //Organizar el array
                Array.Sort(myArray);
                foreach (int i in myArray)
                {
                    //Imprimir array 
                    Console.Write(i.ToString() + ",");
                }


                //Recorrer del 1 al 5 encontrado los valores repetidos 
                for (int z = 1; z <= 5; z++)
                {
                    int firtsnum = z;
                    int cont = 0;

                    foreach (int j in myArray)
                    {
                        //El contador se incrementa cuando encuentre un valor repetido 
                        if (firtsnum == j)
                        {
                            cont++;
                        }
                    }

                    Console.WriteLine();
                    Console.Write(firtsnum.ToString() + ": ");
                    if (cont > 0)
                    {
                        for (int x = 0; x < cont; x++)
                        {
                            Console.Write("*");
                        }
                    }
                    else
                    {
                        Console.Write("");
                    }
                      

                    cont = 0;
                }
               

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

       



        }

    }
}
