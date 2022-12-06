﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AArteagaProgramacionNCapasEntities context = new DL_EF.AArteagaProgramacionNCapasEntities())
                {
                    var paises = context.PaisGetAll().ToList();
                    result.Objects = new List<object>();
                    if (paises != null)
                    {
                       
                        foreach (var row in paises)
                        {
                            ML.Pais pais = new ML.Pais();

                            pais.IdPais = row.IdPais;
                            pais.Nombre = row.Nombre;


                            result.Objects.Add(pais);

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
