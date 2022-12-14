using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.EstadoGetByIdPais(IdPais).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.Estado estado = new ML.Estado();

                            estado.IdEstado = (int)row.IdEstado;
                            estado.Nombre = row.Nombre;

                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = IdPais;


                            result.Objects.Add(estado);

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
