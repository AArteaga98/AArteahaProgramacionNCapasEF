using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt;
            Console.WriteLine("************ELIGE UNA OPCION**************");
            Console.WriteLine("1. ADD\n");
            Console.WriteLine("2. DEL\n");
            Console.WriteLine("3. UPD\n");
            opt=int.Parse(Console.ReadLine());
            Console.WriteLine("***************************");
            switch (opt)
            {
                case 1:
                    Usuario.Add();
                    break;
                    case 2:
                    Usuario.Del();
                    break;
                case 3:
                    Usuario.Upd();
                    break;
                
            }
            
        }
    }
}
