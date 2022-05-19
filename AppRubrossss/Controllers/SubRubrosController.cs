#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppRubrossss.Data;
using AppRubrossss.Models;

namespace AppRubrossss.Controllers
{
    public class SubRubrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubRubrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubRubros
        public IActionResult Index()
        {
            var rubros =  _context.Rubros.Where(e => e.Eliminado == false).ToList();
            ViewBag.RubroID = new SelectList(rubros.OrderBy(e => e.Descripcion), "RubroID", "Descripcion");
            return View();
        }
        //public JsonResult ComboSubRubro(int id)//RUBRO ID
        //{
        //    //BUSCAR SUBRUBROS
        //    var subRubros = (from o in _context.SubRubros where o.RubroID == id && o.Eliminado == false select o).ToList();

        //    return Json(new SelectList(subRubros, "SubrubroID", "Descripcion"));
        //}

        public JsonResult BuscarSubRubros()
        {
            var subRubros = _context.SubRubros.Include(e => e.Rubro).ToList();
            List<SubRubroMostrar> listadoSubRubroMostrar = new List<SubRubroMostrar>();
            var mapSubRubro = subRubros.Select(e => new SubRubroMostrar
            {
                SubrubroID = e.SubrubroID,
                Descripcion = e.Descripcion,
                RubroID = e.RubroID,
                RubroDescripcion = e.Rubro.Descripcion,
                Eliminado= e.Eliminado,

            });

            //foreach (var subRubro in subRubros)
            //{
            //    var mostrar = new SubRubroMostrar
            //    {
            //        SubrubroID = subRubro.SubrubroID,
            //        Descripcion = subRubro.Descripcion,
            //        RubroID = subRubro.RubroID,
            //        RubroDescripcion = subRubro.Rubro.Descripcion,
            //    };
            //    listadoSubRubroMostrar.Add(mostrar)
            //}

            return Json(mapSubRubro);
        }

        public JsonResult GuardarSubRubro(int SubrubroID, string Descripcion, int RubroID)
        {
            bool resultado = true;

            if (!string.IsNullOrEmpty(Descripcion))
            {

                if (SubrubroID == 0)
                {
                    //CREA EL REGISTRO DE RUBRO
                    //PARA ESO CREAMOS UN OBJETO DE TIPO RUBRO CON LOS DATOS NECESARIOS
                    var subRubroNew = new SubRubro
                    {
                        Descripcion = Descripcion,
                        RubroID = RubroID,
                                                
                    };
                    _context.Add(subRubroNew);
                    _context.SaveChanges();
                }
                else
                {
                    //EDITA EL REGISTRO
                    //BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                    var subRubro = _context.SubRubros.Single(m => m.SubrubroID == SubrubroID);
                    //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                    subRubro.Descripcion = Descripcion;
                    subRubro.RubroID = RubroID;
                    _context.SaveChanges();
                }

            }


            return Json(resultado);
        }

        public JsonResult EliminarSubRubro(int SubrubroID, int Elimina)
        {
            bool resultado = true;

            var subrubro = _context.SubRubros.Find(SubrubroID);
            if (subrubro != null)
            {
                if (Elimina == 0)
                {
                    subrubro.Eliminado = false;
                }
                else
                {
                    subrubro.Eliminado = true;

                }
                _context.SaveChanges();
            }

            return Json(resultado);
        }

        public JsonResult BuscarSubRubro(int SubrubroID)
        {
            var subRubro = _context.SubRubros.FirstOrDefault(m => m.SubrubroID == SubrubroID);

            return Json(subRubro);
        }


        public JsonResult ComboSubRubro(int id)//RUBRO ID
        {
            //BUSCAR SUBRUBROS
            var subRubros = (from o in _context.SubRubros where o.RubroID == id && o.Eliminado == false select o).ToList();

            return Json(new SelectList(subRubros, "SubrubroID", "Descripcion"));
        }
    }

}
