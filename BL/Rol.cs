using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.RolGetAll().ToList();
                   
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = row.IdRol;
                            rol.Nombre = row.Nombre;


                            result.Objects.Add(rol);

                        }
                       
                    }
                    
                }
                result.Correct = true;
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

