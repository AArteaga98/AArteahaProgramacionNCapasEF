using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var query = context.ColoniaGetByIdMunicipio(IdMunicipio).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.Colonia colonia = new ML.Colonia();

                            colonia.IdColonia = row.IdColonia;
                            colonia.Nombre = row.Nombre;
                            //colonia.CP = row.CP;

                            colonia.Municipio = new ML.Municipio();
                            colonia.Municipio.IdMunicipio = IdMunicipio;


                            result.Objects.Add(colonia);

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
