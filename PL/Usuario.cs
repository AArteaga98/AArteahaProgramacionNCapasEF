using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {

        public  static void Add()
        {
            ML.Usuario usuario = new ML.Usuario(); // Esta es la intasncia - ML.Usuario es el obj
            Console.WriteLine("Ingresa los datos del Usuario");
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Fecha de Nacimento");
            usuario.FechaNacimineto = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Genero ( M - F )");
            usuario.Genero = char.Parse(Console.ReadLine());

            // Se llena el objeto con la informacion
            ML.Result result = BL.Usuario.Add(usuario); // Se envia el obj ya con la infomacion

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

        }

        public static void Del()
        {
            ML.Usuario usuario = new ML.Usuario(); // Esta es la intasncia - ML.Usuario es el obj
            Console.WriteLine("Ingresa el Id del Usuario  a Eliminar");
            usuario.IdUsuario = int.Parse( Console.ReadLine());

            // Se llena el objeto con la informacion
            ML.Result result = BL.Usuario.Del(usuario); // Se envia el obj ya con la infomacion

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

        }

        public static void Upd()
        {
            ML.Usuario usuario = new ML.Usuario(); // Esta es la intasncia - ML.Usuario es el obj
            Console.WriteLine("Ingresa el Id del Usuario  a Actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa los Nuevos datos del Usuario");
            Console.WriteLine("\nNombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("\nApellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("\nApellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("\nFecha de Nacimento");
            usuario.FechaNacimineto = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nGenero ( M - F )");
            usuario.Genero = char.Parse(Console.ReadLine());

            // Se llena el objeto con la informacion
            ML.Result result = BL.Usuario.Del(usuario); // Se envia el obj ya con la infomacion

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

        }

    }

    
}
