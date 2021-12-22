using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Conway
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double density;
            Console.WriteLine("Enter the population density(%)");
            density = double.Parse(Console.ReadLine());
           
                Generation gen = new Generation(20, 20, density);


            //  gen.one();
            Generation generation = new Generation(gen,"#");
            const int FPS = 24;
                 for (int c = 0; c < 100; c++)
                   {
                    Thread.Sleep(1000 / FPS);
                   
                    
                new Generation(gen,"#");
                gen.step();
               
            }
            Generation generation1 = new Generation(gen, "#");
            generation1.ToString();






        }
    }
}
