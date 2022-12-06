using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll(ML.Usuario usuario)
        { 
            ML.Result result =  BL.Usuario.GetAllEF(usuario);
            //ML.Usuario usuario=new ML.Usuario();
            if (result.Correct)
            {
                usuario.Usuarios=result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
           

            ML.Usuario usuario = new ML.Usuario();

            usuario.Rol = new ML.Rol();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais= new ML.Pais();

            ML.Result resultRol = BL.Rol.GetAll();
            ML.Result resultPaises = BL.Pais.GetAll();
           

            if (IdUsuario==null)
            {
               
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;    
                return View(usuario);

            }
            else
            {
                //GetById
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles=resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

                    ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.IdColonia);

                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                    usuario.Direccion.Colonia.Colonias = resultColonias.Objects;


                    return View(usuario);
                   
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el Usuario seleccionado";
                }
                return View(usuario);
            }
        }

        [HttpPost]
        //ADD
        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                ML.Result result = BL.Usuario.AddEF(usuario);

                //HttpPostedFileBase file = Request.Files["ImagenData"];
                //if (file.ContentLength > 0)
                //{
                //    usuario.Imagen = ConvertToBytes(file);
                //}

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message= "Error:  " + result.Message;
                }

            }
            else
            {
               ML.Result result= BL.Usuario.UpdateEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message= "ERROR: " + result.Message;
                }
            }

            return PartialView("Modal");
        } 

        //delete
        public ActionResult Delete(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(usuario);
            if (result.Correct)
            {
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "ERROR: " + result.Message;
            }
            return PartialView("Modal");
        }
        
        
        //JSON
        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);


            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public static byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);
            return data;
        }


    }

}