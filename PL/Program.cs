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
           
            Console.WriteLine("************Usuario**************\n");
            Console.WriteLine("1. Agregar     |||||||||||||||||  2. Ver  \n");
            Console.WriteLine("3. Ver por Id   |||||||||||||||||  4. Actualizar  \n");
            Console.WriteLine("5. Borrar        |||||||||||||||||  \n");

            Console.WriteLine("************Empresa**************\n");
            Console.WriteLine("6. Agregar     |||||||||||||||||  7. Ver \n");
            Console.WriteLine("8. Ver por Id  |||||||||||||||||  9. Actualizar \n");
            Console.WriteLine("10. Borrar      |||||||||||||||||  \n");

            Console.WriteLine("************ELIGE UNA OPCION**************");
             opt =int.Parse(Console.ReadLine());
            Console.WriteLine("***************************");
            switch (opt)
            {
                //USUARIO

                case 1:
                    Usuario.Add();
                    break;
               case 2:
                    Usuario.GetAll();
                    break;
                case 3:
                    Usuario.GetById();
                    break;
                case 4:
                    Usuario.Update();
                    break;

                case 5:
                    Usuario.Delete();
                    break;

                    //EMPRESA
                case 6:
                    Empresa.Add();
                    break;
                case 7:
                   Empresa.GetAll();
                    break;
                case 8:
                    Empresa.GetById();
                    break;
                case 9:
                    Empresa.Update();
                    break;
                case 10:
                    Empresa.Delete();
                    break;

            }

        }
    }
}
