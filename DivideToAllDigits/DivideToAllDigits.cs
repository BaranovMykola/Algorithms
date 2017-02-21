using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideToAllDigits
{
    class DivideToAllDigits
    {
        static void Main(string[] args)
        {
            int number = 123;
            int copy = number;
            bool error = false;
            if(Math.Abs(number) < 10)
            {
                error = true;
                Console.WriteLine("Can't divide");
            }
            while(number != 0)
            {
                int digit = number % 10;
                number /= 10;
                if(copy%digit != 0)
                {
                    Console.WriteLine("Can't divide by {0} ", digit);
                    error = true;
                }
            }
            if(!error)
            {
                Console.WriteLine("Divided successfully");
            }
            Console.ReadKey();
        }
    }
}
