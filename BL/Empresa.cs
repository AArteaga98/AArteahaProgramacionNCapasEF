using ML;
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
    public class Empresa
    {

        //SP
        public static ML.Result Add(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "EmpresaAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = empresa.Nombre;

                        collection[1] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[1].Value = empresa.Telefono;

                        collection[2] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[2].Value = empresa.Email;

                        collection[3] = new SqlParameter("DireccionWeb", SqlDbType.VarChar);
                        collection[3].Value = empresa.DireccionWeb;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego la empresa correctamente";

                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar la empresa" + result.Ex;
                Console.ReadKey();
                throw;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "EmpresaGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        DataTable empresaTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(empresaTable);

                        if (empresaTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in empresaTable.Rows)
                            {
                                ML.Empresa empresa = new ML.Empresa();

                                empresa.IdEmpresa = int.Parse(row[0].ToString());
                                empresa.Nombre = row[1].ToString();
                                empresa.Telefono = row[2].ToString();
                                empresa.Email = row[3].ToString();
                                empresa.DireccionWeb = row[4].ToString();
                                
                                result.Objects.Add(empresa);

                            }

                        }

                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error en la consulta del alumno" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result GetById(int IdEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "EmpresaGetById";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdEmpresa", SqlDbType.Int);
                        collection[0].Value = IdEmpresa;

                        cmd.Parameters.AddRange(collection);

                        DataTable empresaTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(empresaTable);

                        if (empresaTable.Rows.Count > 0)
                        {
                            DataRow row = empresaTable.Rows[0];

                            ML.Empresa empresa = new ML.Empresa();


                            empresa.IdEmpresa = int.Parse(row[0].ToString());
                            empresa.Nombre = row[1].ToString();
                            empresa.Telefono = row[2].ToString();
                            empresa.Email = row[3].ToString();
                            empresa.DireccionWeb = row[4].ToString();

                            result.Object = empresa;//boxing 

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

        public static ML.Result Update(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "EmpresaUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("IdEmpresa", SqlDbType.Int);
                        collection[0].Value = empresa.IdEmpresa;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = empresa.Nombre;

                        collection[2] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[2].Value = empresa.Telefono;

                        collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[3].Value = empresa.Email;

                        collection[4] = new SqlParameter("DireccionWeb", SqlDbType.VarChar);
                        collection[4].Value = empresa.DireccionWeb;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se Modifico la Empresa correctamente";

                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al modificar Empresa" + result.Ex;
                Console.ReadKey();

            }//manejo de excepciones 
            return result;

        }

        public static ML.Result Delete(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "EmpresaDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdEmpresa", SqlDbType.TinyInt);
                        collection[0].Value = empresa.IdEmpresa;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se elimino la empresa correctamente";

                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al Eliminar la Empresa" + result.Ex;
                Console.ReadKey();

            }//manejo de excepciones 
            return result;

        }

        //EF
        public static ML.Result AddEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    int query = context.EmpresaAdd(empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb,empresa.Logo);

                    if (query > 0)
                    {
                        result.Message = "Empresa Registrada con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al agregar empresa" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.EmpresaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = obj.IdEmpresa;
                            empresa.Nombre = obj.Nombre;
                            empresa.Telefono = obj.Telefono;
                            empresa.Email = obj.Email;
                            empresa.DireccionWeb = obj.DireccionWeb;
                            

                            result.Objects.Add(empresa);

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
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int IdEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.EmpresaGetById(IdEmpresa).Single();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Empresa empresa = new ML.Empresa();
                        empresa.IdEmpresa = query.IdEmpresa;
                        empresa.Nombre = query.Nombre;
                        empresa.Telefono = query.Telefono;
                        empresa.Email = query.Email;
                        empresa.DireccionWeb = query.DireccionWeb;
                       
                        result.Object = empresa;//boxing del obj
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al obtener registros";
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

        public static ML.Result UpdateEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    int query = context.EmpresaUpdate(empresa.IdEmpresa, empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb,empresa.Logo);

                    if (query > 0)
                    {
                        result.Message = "Empresa Modificada con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al modificar empresa" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result DeleteEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    int query = context.EmpresaDelete(empresa.IdEmpresa);

                    if (query > 0)
                    {
                        result.Message = "Empresa Eliminada con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar empresa" + result.Ex;
                throw;
            }
            return result;
        }

        //LINQ
         public static  ML.Result AddLQ(ML.Empresa empresa)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    DL_EF.Empresa empresaa = new DL_EF.Empresa();
                    empresaa.Nombre = empresa.Nombre;
                    empresaa.Telefono= empresa.Telefono;
                    empresaa.Email = empresa.Email;
                    empresaa.DireccionWeb= empresa.DireccionWeb;
                    
                    context.Empresas.Add(empresaa);
                    context.SaveChanges();

                    result.Message = "Empresa Registrada con exito";
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
         public static ML.Result DeleteLQ(ML.Empresa empresa) 
        { 
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query =( from a in context.Empresas where a.IdEmpresa== empresa.IdEmpresa select a).First();
                   
                    context.Empresas.Remove(query);
                    context.SaveChanges();

                    result.Message = "Empresa Eliminada con exito";
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.Message= ex.Message;
                throw;
            }
            return result;

        }   
         public static ML.Result UpdateLQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = (from a in context.Empresas where a.IdEmpresa == empresa.IdEmpresa select a).SingleOrDefault();
                    if (query!= null)
                    {
                        query.IdEmpresa = empresa.IdEmpresa;
                        query.Nombre = empresa.Nombre;
                        query.Telefono = empresa.Telefono;
                        query.Email = empresa.Email;
                        query.DireccionWeb = empresa.DireccionWeb;

                        context.SaveChanges();
                        result.Message = "Empresa moficada con exito";
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

         public static ML.Result GetAllLQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = from Empresa in context.Empresas select Empresa;
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count>0)
                    {
                        foreach(var obj in query)
                        {
                            ML.Empresa empresa = new ML.Empresa(); 
                            empresa.IdEmpresa=obj.IdEmpresa;
                            empresa.Nombre=obj.Nombre;
                            empresa.Telefono=obj.Telefono;
                            empresa.Email=obj.Email;
                            empresa.DireccionWeb=obj.DireccionWeb;

                            result.Objects.Add(empresa);
                            result.Message = "ok";
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Message = "Empresa Registrada sin exito";
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }

        public static ML.Result GetByIdLQ(int IdEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = (from Empresa in context.Empresas where Empresa.IdEmpresa == IdEmpresa select Empresa).Single();
                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        ML.Empresa empresa = new ML.Empresa();

                        empresa.IdEmpresa = query.IdEmpresa;
                        empresa.Nombre = query.Nombre;
                        empresa.Telefono = query.Telefono;
                        empresa.Email = query.Email;
                        empresa.DireccionWeb = query.DireccionWeb;

                        result.Object = empresa; //boxing del obj

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

    }
}
