using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        //Consultas por Query
        public static void AddQ()
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
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Genero ( M - F )");
            usuario.Genero = Console.ReadLine();

            // Se llena el objeto con la informacion
            ML.Result result = BL.Usuario.Add(usuario); // Se envia el obj ya con la infomacion
            

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

        }

        public static void DelQ()
        {
            ML.Usuario usuario = new ML.Usuario(); // Esta es la intasncia - ML.Usuario es el obj
            Console.WriteLine("Ingresa el Id del Usuario  a Eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            // Se llena el objeto con la informacion
            ML.Result result = BL.Usuario.Del(usuario); // Se envia el obj ya con la infomacion

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

        }

        public static void UpdQ()
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
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("\nGenero ( M - F )");
            usuario.Genero = Console.ReadLine();

            // Se llena el objeto con la informacion
            ML.Result result = BL.Usuario.Upd(usuario); // Se envia el obj ya con la infomacion

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

        }



        //Consultas por SP / EF / LQ 
        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAllSP();
           //ML.Result result = BL.Usuario.GetAllEF();
            ML.Result result = BL.Usuario.GetAllLQ();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("El id del usuario es:" + usuario.IdUsuario);
                    Console.WriteLine("El nombre del usuario es:" + usuario.Nombre);
                    Console.WriteLine("El apellido paterno del usuario es:" + usuario.ApellidoPaterno);
                    Console.WriteLine("El apellido materno del usuario es:" + usuario.ApellidoMaterno);
                    Console.WriteLine("La fecha de nacimiento del usuario es:" + usuario.FechaNacimiento.ToString());
                    Console.WriteLine("El UserName del usuario es:" + usuario.UserName);
                    Console.WriteLine("El Email del usuario es:" + usuario.Email);
                    Console.WriteLine("El Password del usuario es:" + usuario.Password);
                    Console.WriteLine("El Telefono del usuario es:" + usuario.Telefono);
                    Console.WriteLine("El Celular del usuario es:" + usuario.Celular);
                    Console.WriteLine("El CURP del usuario es:" + usuario.CURP);
                    Console.WriteLine("El Semestre del usuario es:" + usuario.Rol.IdRol);
                    Console.WriteLine("----------------------------------------------------------");
                    
                }
                Console.ReadKey();
            }
        }

        public static void Add()
        {

            ML.Usuario usuario = new ML.Usuario(); // Esta es la intasncia - ML.Usuario es el obj

            Console.WriteLine("Ingresa los datos del Usuario");
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Fecha de Nacimento (dd-mm-yyyy)");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Genero ( M - F )");
            usuario.Genero = Console.ReadLine();

            Console.WriteLine("UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("PassWord");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("CURP");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Id Rol");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = Byte.Parse(Console.ReadLine());


                     // Se llena el objeto con la informacion
           // ML.Result result = BL.Usuario.AddSP(usuario);// STORED enviamos el objeto con informacion 
            //ML.Result result = BL.Usuario.AddEF(usuario); // EF
            ML.Result result = BL.Usuario.AddLQ(usuario); // LQ

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
                Console.ReadKey();
            }
        }

        public static void Update()
        {

            ML.Usuario usuario = new ML.Usuario(); // Esta es la intasncia - ML.Usuario es el obj

            Console.WriteLine("Ingresa el ID del Usuario a actualizar");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa los datos nuevos del Usuario");
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Fecha de Nacimento (dd-mm-yyyy)");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Genero ( M - F )");
            usuario.Genero = Console.ReadLine();

            Console.WriteLine("UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("PassWord");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("CURP");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Id Rol");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = Byte.Parse(Console.ReadLine());


            // Se llena el objeto con la informacion
            //ML.Result result = BL.Usuario.UpdSP(usuario);// SP enviamos el objeto con informacion 
            //ML.Result result = BL.Usuario.UpdateEF(usuario); //EF
            ML.Result result = BL.Usuario.UpdateLQ(usuario); //LQ

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
                Console.ReadKey();
            }
        }

        public static void Delete()
        {

            ML.Usuario usuario = new ML.Usuario(); // Esta es la intasncia - ML.Usuario es el obj

            Console.WriteLine("Ingresa el ID del Usuario a eliminar");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            // Se llena el objeto con la informacion
           // ML.Result result = BL.Usuario.DeleteSP(usuario);// STORED enviamos el objeto con informacion 
            //ML.Result result = BL.Usuario.DeleteEF(usuario);// EF enviamos el objeto con informacion 
            ML.Result result = BL.Usuario.DeleteLQ(usuario);// LQ enviamos el objeto con informacion 


            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
                Console.ReadKey();
            }
        }

        public static void GetById()
        {

            ML.Usuario usuario = new ML.Usuario(); // Esta es la intasncia - ML.Usuario es el obj

            Console.WriteLine("Ingresa el ID del Usuario que quieres ver");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());
            //ML.Result result = BL.Usuario.GetByIdSP(usuario.IdUsuario); //STORED
           // ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario); //ENTITY FRAMEWORK
            ML.Result result = BL.Usuario.GetByIdLQ(usuario.IdUsuario); //LinQ

            if (result.Correct)
            {

                usuario = (ML.Usuario)result.Object;//unboxing

                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("El id del usuario es:" + usuario.IdUsuario);
                    Console.WriteLine("El nombre del usuario es:" + usuario.Nombre);
                    Console.WriteLine("El apellido paterno del usuario es:" + usuario.ApellidoPaterno);
                    Console.WriteLine("El apellido materno del usuario es:" + usuario.ApellidoMaterno);
                    Console.WriteLine("La fecha de nacimiento del usuario es:" + usuario.FechaNacimiento.ToString());
                    Console.WriteLine("El UserName del usuario es:" + usuario.UserName);
                    Console.WriteLine("El Email del usuario es:" + usuario.Email);
                    Console.WriteLine("El Password del usuario es:" + usuario.Password);
                    Console.WriteLine("El Telefono del usuario es:" + usuario.Telefono);
                    Console.WriteLine("El Celular del usuario es:" + usuario.Celular);
                    Console.WriteLine("El CURP del usuario es:" + usuario.CURP);
                    Console.WriteLine("El Semestre del usuario es:" + usuario.Rol.IdRol);
                    Console.WriteLine("----------------------------------------------------------");
                    Console.ReadKey();
                

            }
        }


    }
}
