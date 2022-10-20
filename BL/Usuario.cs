using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[3].Value = usuario.FechaNacimineto;

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
        ///////////////
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
        ////////////////////////////////////////////
        ///

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

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[3].Value = usuario.FechaNacimineto;

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
    }
}

