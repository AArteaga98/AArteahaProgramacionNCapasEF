using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();


                            aseguradora.IdAseguradora = obj.IdAseguradora;
                            aseguradora.Nombre = obj.Nombre;
                            aseguradora.FechaCreacion = obj.FechaCreacion.Value.ToString("dd/MM/yyyy");
                            aseguradora.FechaModificacion = obj.FechaModificacion.Value.ToString("dd/MM/yyyy");
                            //aseguradora.Usuario.IdUsuario = (int)obj.IdUsuario;



                            result.Objects.Add(aseguradora);

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
        public static ML.Result GetByIdEF(int IdAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetById(IdAseguradora).Single();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;
                        aseguradora.FechaCreacion = query.FechaCreacion.Value.ToString("dd/MM/yyyy");
                        aseguradora.FechaModificacion = query.FechaModificacion.Value.ToString("dd/MM/yyyy");

                        result.Object = aseguradora;//boxing del obj
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
               
            }
            return result;
        }
        public static ML.Result AddEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraAdd(aseguradora.Nombre,  aseguradora.Usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Message = "Aseguradora Registrada con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al agregar aseguradora" + result.Ex;
                
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraUpdate(aseguradora.Nombre, aseguradora.IdAseguradora);

                    if (query > 0)
                    {
                        result.Message = "Aseguradora Modificada con exito";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al modificar aseguradora" + result.Ex;
                throw;
            }
            return result;
        }

        public static ML.Result DeleteEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraDelete(aseguradora.IdAseguradora);

                    if (query > 0)
                    {
                        result.Message = "Aseguradora Eliminada con exito";
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
    }
}
