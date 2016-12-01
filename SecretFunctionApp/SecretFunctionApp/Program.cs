using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretFunctionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input an Int");
            int? input = null;
            try
            {
                input = Int16.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invaild input");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            if (input != null)
            {
                
            }
        }
    }
}
