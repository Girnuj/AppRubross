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
    public class RubrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RubrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public JsonResult BuscarRubros()
        {
            var rubros = _context.Rubros.ToList();

            return Json(rubros);
        }
        public JsonResult GuardarRubro(int RubroID, string Descripcion)
        {
            bool resultado = true;

            if (!string.IsNullOrEmpty(Descripcion))
            {

                if (RubroID == 0)
                {
                    //CREA EL REGISTRO DE RUBRO
                    //PARA ESO CREAMOS UN OBJETO DE TIPO RUBRO CON LOS DATOS NECESARIOS
                    var rubro = new Rubro
                    {
                        Descripcion = Descripcion
                    };
                    _context.Add(rubro);
                    _context.SaveChanges();
                }
                else
                {
                    //EDITA EL REGISTRO
                    //BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                    var rubro = _context.Rubros.Single(m => m.RubroID == RubroID);
                    //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                    rubro.Descripcion = Descripcion;
                    _context.SaveChanges();
                }

            }


            return Json(resultado);
        }

        public JsonResult BuscarRubro(int RubroID)
        {
            var rubro = _context.Rubros.FirstOrDefault(m => m.RubroID == RubroID);

            return Json(rubro);
        }

        public JsonResult EliminarRubro(int RubroID, int Elimina)
        {
            bool resultado = true;

            var rubro = _context.Rubros.Find(RubroID);
            if (rubro != null)
            {
                if (Elimina == 0)
                {
                    rubro.Eliminado = false;
                }
                else
                {
                    rubro.Eliminado = true;

                }
                _context.SaveChanges();
            }

            return Json(resultado);
        }

        // GET: Rubros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rubros.ToListAsync());
        }

     
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("RubroID,Descripcion")] Rubro rubro)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(rubro);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(rubro);
        //}

       
    }
}
