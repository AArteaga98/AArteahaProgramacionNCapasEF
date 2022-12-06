using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Empresa
    {
        //CONSULTAS CON SP /EF /LinQ
        public static void Add()
        {
            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("***************INGRESA LOS DATOS DE LA NUEVA EMPRESA");
            Console.WriteLine("\nNombre");
            empresa.Nombre= Console.ReadLine();
            Console.WriteLine("\nTelefono");
            empresa.Telefono = Console.ReadLine();
            Console.WriteLine("\nEmail");
            empresa.Email = Console.ReadLine();
            Console.WriteLine("\nDireccion Web");
            empresa.DireccionWeb = Console.ReadLine();

            // ML.Result result=BL.Empresa.Add(empresa); //SP
            // ML.Result result=BL.Empresa.AddEF(empresa); //EF
             ML.Result result=BL.Empresa.AddLQ(empresa); //LinQ

            if (result.Correct)
            {
                Console.WriteLine("\nMensaje: " + result.Message);
                Console.ReadKey();
            }
        }

        public static void GetAll()
        {
            

            // ML.Result result = BL.Empresa.GetAll(); //STORED
            //ML.Result result = BL.Empresa.GetAllEF(); // EF
            ML.Result result = BL.Empresa.GetAllLQ(); // LQ

            if (result.Correct)
            {
                foreach (ML.Empresa empresa in result.Objects)
                {
                    Console.WriteLine("El id del empresa es: " + empresa.IdEmpresa);
                    Console.WriteLine("El nombre del empresa es: " + empresa.Nombre);
                    Console.WriteLine("El telefono de la empresa es: " + empresa.Telefono);
                    Console.WriteLine("El email es: " + empresa.Email);
                    Console.WriteLine("La Direccion de la empresa es: " + empresa.DireccionWeb);
                    Console.WriteLine("----------------------------------------------------------");
                    Console.ReadKey();
                }
            }
        }

        public static void GetById()
        {
            ML.Empresa empresa = new ML.Empresa();
            Console.WriteLine("Ingresa el Id de la Empresa que quieres ver: ");
            empresa.IdEmpresa=int.Parse(Console.ReadLine());

            //ML.Result result = BL.Empresa.GetById(empresa.IdEmpresa);//STORED
           // ML.Result result = BL.Empresa.GetByIdEF(empresa.IdEmpresa);//EF
            ML.Result result = BL.Empresa.GetByIdLQ(empresa.IdEmpresa);//LQ
            if (result.Correct)
            {
                empresa = (ML.Empresa)result.Object; //unboxing del obj
                Console.WriteLine("\nEl id del empresa es: " + empresa.IdEmpresa);
                Console.WriteLine("\nEl nombre del empresa es: " + empresa.Nombre);
                Console.WriteLine("\nEl telefono de la empresa es: " + empresa.Telefono);
                Console.WriteLine("\nEl email es: " + empresa.Email);
                Console.WriteLine("\nLa Direccion de la empresa es: " + empresa.DireccionWeb);
                Console.WriteLine("----------------------------------------------------------");
                Console.ReadKey();

            }

        }

        public static void Update()
        {

            ML.Empresa empresa = new ML.Empresa(); // Esta es la intasncia - ML.Usuario es el obj

            Console.WriteLine("Ingresa el ID de la Empresa a actualizar");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa los datos nuevos de la Empresa\n");
            Console.WriteLine("\nNombre");
            empresa.Nombre = Console.ReadLine();

            Console.WriteLine("\nTelefono");
            empresa.Telefono = Console.ReadLine();

            Console.WriteLine("\nEmail");
            empresa.Email = Console.ReadLine();

            Console.WriteLine("\nDireccion Web");
            empresa.DireccionWeb = Console.ReadLine();
            // Se llena el objeto empresa con la informacion

            //ML.Result result = BL.Empresa.Update(empresa);// STORED enviamos el objeto con informacion 
            //ML.Result result = BL.Empresa.UpdateEF(empresa);// EF enviamos el objeto con informacion 
            ML.Result result = BL.Empresa.UpdateLQ(empresa);// EF enviamos el objeto con informacion 

            if (result.Correct)
            {
                Console.WriteLine("\nMensaje: " + result.Message);
                Console.ReadKey();
            }
        }

        public static void Delete()
        {

            ML.Empresa empresa = new ML.Empresa(); // Esta es la intasncia - ML.Usuario es el obj

            Console.WriteLine("Ingresa el ID de la Empresa a eliminar");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            // Se llena el objeto con la informacion
            //ML.Result result = BL.Empresa.Delete(empresa);// SP   enviamos el objeto con informacion 
            //ML.Result result = BL.Empresa.DeleteEF(empresa);// EF  enviamos el objeto con informacion 
            ML.Result result = BL.Empresa.DeleteLQ(empresa);// LinQ  enviamos el objeto con informacion 

            if (result.Correct)
            {
                Console.WriteLine("\nMensaje: " + result.Message);
                Console.ReadKey();
            }
        }

       
    }
}
