using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion() ) )
                {
                    string query = "INSERT INTO[Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Genero])VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Genero)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; // conexion
                        cmd.CommandText = query; // consulta

                        context.Open();
                        SqlParameter[] collection = new SqlParameter[5];

                        //Primero se tiene que crear las propiedades en ML clase Usuario

                        

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[4].Value = usuario.Genero;

                        cmd.Parameters.AddRange(collection);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el Usuario Correctamente";
                        }
                }
             }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex=ex;
                result.Message = "Ocurrio un error en el registro" + result.Ex;

                throw;
            }
            return result;
        }
    
        public static ML.Result Del(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DELETE FROM [Usuario] WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; // conexion
                        cmd.CommandText = query; // consulta

                        context.Open();
                        SqlParameter[] collection = new SqlParameter[1];

                        //Primero se tiene que crear las propiedades en ML clase Usuario

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;


                        cmd.Parameters.AddRange(collection);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se Elimino el Usuario Correctamente";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error en el registro" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result Upd(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UPDATE [Usuario] SET ([Nombre] = @Nombre,[ApellidoPaterno]= @ApellidoPaterno,[ApellidoMaterno]= @ApellidoMaterno,[FechaNacimiento]= @FechaNacimiento,[Genero]= @Genero) WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; // conexion
                        cmd.CommandText = query; // consulta

                        context.Open();
                        SqlParameter[] collection = new SqlParameter[6];

                        //Primero se tiene que crear las propiedades en ML clase Usuario


                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[4].Value = usuario.Genero;

                        cmd.Parameters.AddRange(collection);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se modifico el Usuario Correctamente";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error en el proceso" + result.Ex;

                throw;
            }
            return result;
        }

        //STORED PROCEDURE
        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "UsuarioGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();
                                usuario.Genero = row[5].ToString();
                                usuario.UserName= row[6].ToString();
                                usuario.Email= row[7].ToString();
                                usuario.Password= row[8].ToString();
                                usuario.Telefono= row[9].ToString();
                                usuario.Celular= row[10].ToString();
                                usuario.CURP= row[11].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                                result.Objects.Add(usuario); 

                            }

                        }

                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error en la consulta del alumno" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[4].Value = usuario.Genero;

                        collection[5] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[5].Value = usuario.UserName;

                        collection[6] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;


                        collection[11] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el usuario correctamente";
                            
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;
                Console.ReadKey();

            }//manejo de excepciones 
            return result;

        }

        public static ML.Result UpdSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[5].Value = usuario.Genero;

                        collection[6] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[6].Value = usuario.UserName;

                        collection[7] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[7].Value = usuario.Email;

                        collection[8] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[8].Value = usuario.Password;

                        collection[9] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[9].Value = usuario.Telefono;

                        collection[10] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[10].Value = usuario.Celular;

                        collection[11] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[11].Value = usuario.CURP;

                        collection[12] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[12].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se Modifico el alumno correctamente";

                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al modificar el usuario" + result.Ex;
                Console.ReadKey();

            }//manejo de excepciones 
            return result;

        }

        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.TinyInt);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se elimino el alumno correctamente";

                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;
                Console.ReadKey();

            }//manejo de excepciones 
            return result;

        }

        public static ML.Result GetByIdSP(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "UsuarioGetById";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            DataRow row = usuarioTable.Rows[0];
                          
                            ML.Usuario usuario = new ML.Usuario();


                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = row[4].ToString();
                            usuario.Genero = row[5].ToString();
                            usuario.UserName = row[6].ToString();
                            usuario.Email = row[7].ToString();
                            usuario.Password = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                            result.Object = usuario;//boxing 
                            
                        }

                    }

                }
                result.Correct = true;


            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error en la consulta" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        //EF
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context= new DL_EF.AArteagaProgramacionNCapasEntities() )
                {
                    int query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Genero, usuario.UserName, usuario.Email, usuario.Password, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol,usuario.Imagen,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query>0)
                    {
                        result.Message = "Usuario Registrado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al agregar usuario" + result.Ex;
                throw;
            }
            return result;
        }
        
        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno, usuario.Rol.IdRol).ToList();
                    
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            //ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = row.IdUsuario;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno= row.ApellidoPaterno;
                            usuario.ApellidoMaterno= row.ApellidoMaterno;
                            usuario.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd/MM/yyyy"); 
                            usuario.Genero= row.Genero;
                            usuario.UserName= row.UserName;
                            usuario.Email= row.Email;
                            usuario.Password= row.Password;
                            usuario.Telefono= row.Telefono;
                            usuario.Celular= row.Celular;
                            usuario.CURP= row.CURP;
                           
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (byte)row.IdRol;
                            usuario.Rol.Nombre = row.RolNombre;
                            //usuario.Imagen = row.Imagen;
                            usuario.Status = (bool)row.Status;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                            usuario.Direccion.IdDireccion = (byte)row.IdDirreccion;
                            usuario.Direccion.Calle = row.Calle;
                            usuario.Direccion.NumeroInterior = row.NumeroInterior;
                            usuario.Direccion.NumeroExterior = row.NumeroExterior;
                            usuario.Direccion.Colonia.IdColonia = (byte)row.IdColonia;
                            usuario.Direccion.Colonia.Nombre = row.ColoniaNombre;
                            usuario.Direccion.Colonia.CP = row.CP;
                            usuario.Direccion.Colonia.Municipio.IdMunicipio =(byte)row.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = row.MunicipioNombre;
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = (byte)row.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = row.EstadoNombre;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = (byte)row.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = row.PaisNombre;


                            result.Objects.Add(usuario);
                            
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Message = ex.Message;
               
            }
            return result;
        }

       public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetById(IdUsuario).Single();
                    result.Objects = new List<object>();
                    if (query !=null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario=query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy"); ;
                        usuario.Genero = query.Genero;
                        usuario.UserName = query.UserName;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = (byte)query.IdRol;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                        usuario.Direccion.IdDireccion = (byte)query.IdDirreccion;
                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.NumeroInterior = query.NumeroInterior;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;
                        usuario.Direccion.Colonia.IdColonia = (byte)query.IdColonia;
                        usuario.Direccion.Colonia.Nombre = query.ColoniaNombre;
                        
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = (byte)query.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.MunicipioNombre;
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = (byte)query.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.EstadoNombre;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = (byte)query.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.PaisNombre;


                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                        result.Message = "Error al obtener registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Message=ex.Message;
                result.Ex=ex;
                throw;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    int query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Genero, usuario.UserName, usuario.Email, usuario.Password, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol,usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query >0)
                    {
                        result.Message = "Usuario Modificado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al modificar usuario" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    int query = context.UsuarioDelete(usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Message = "Usuario Eliminado con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar usuario" + result.Ex;
                throw;
            }
            return result;
        }

        //LinQ

        public static ML.Result AddLQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioo = new DL_EF.Usuario();
                    usuarioo.Nombre = usuario.Nombre;
                        usuarioo.ApellidoPaterno= usuario.ApellidoPaterno;
                        usuarioo.ApellidoMaterno= usuario.ApellidoMaterno;
                        usuarioo.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        usuarioo.Genero = usuario.Genero;
                    usuarioo.UserName = usuario.UserName;
                    usuarioo.Email = usuario.Email;
                    usuarioo.Password = usuario.Password;
                    usuarioo.Telefono = usuario.Telefono;
                    usuarioo.Celular = usuario.Celular;
                    usuarioo.CURP = usuario.CURP;
                    usuarioo.IdRol= usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioo);
                    context.SaveChanges();

                    result.Message = "Usuario Registrado con exito";
                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
                throw;
            }
            return result;
        }

        public static ML.Result GetAllLQ()
        {
            ML.Result result = new ML.Result();
            try 
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = from Usuario in context.Usuarios select Usuario;
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            usuario.Genero = obj.Genero;
                            usuario.UserName = obj.UserName;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (byte)obj.IdRol;


                            result.Objects.Add(usuario);
                            result.Message = "Exito";
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Message = " Sin Exito";
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }

        public static ML.Result GetByIdLQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuarios where Usuario.IdUsuario == IdUsuario select Usuario).Single();
                    result.Objects = new List<object>();
                    if (query != null )
                    {
                       
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = query.IdUsuario;
                            usuario.Nombre = query.Nombre;
                            usuario.ApellidoPaterno = query.ApellidoPaterno;
                            usuario.ApellidoMaterno = query.ApellidoMaterno;
                            usuario.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            usuario.Genero = query.Genero;
                            usuario.UserName = query.UserName;
                            usuario.Email = query.Email;
                            usuario.Password = query.Password;
                            usuario.Telefono =  query.Telefono;
                            usuario.Celular = query.Celular;
                            usuario.CURP = query.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (byte)query.IdRol;

                            result.Object = usuario; //boxing del obj
                       
                            result.Correct = true;
                        
                    }
                    else
                    {
                        
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }

        public static ML.Result UpdateLQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = (from a in context.Usuarios where a.IdUsuario == usuario.IdUsuario select a).SingleOrDefault();
                    if (query != null)
                    {
                        query.IdUsuario = usuario.IdUsuario;
                        query.Nombre = usuario.Nombre;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        query.Genero = usuario.Genero;
                        query.UserName = usuario.UserName;
                        query.Email = usuario.Email;
                        query.Password = usuario.Password;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();
                        result.Message = "Usuario moficado con exito";
                        result.Correct = true;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
                throw;
            }
            return result;
        }

        public static ML.Result DeleteLQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = (from a in context.Usuarios where a.IdUsuario == usuario.IdUsuario select a).First();

                    context.Usuarios.Remove(query);
                    context.SaveChanges();

                    result.Message = "Usuario eliminado con exito";
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }
            return result;

        }



    }
}

