using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppRubrossss.Data;
using AppRubrossss.Models;
using System.Globalization;

namespace AppRubrossss.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articulos
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.Articulos.Include(a => a.SubRubro);
        //    return View(await applicationDbContext.ToListAsync());
        //}
        public IActionResult Index()
        {
            //var subrubros = _context.SubRubros.Where(e => e.Eliminado == false).ToList();
            //ViewBag.SubrubroID = new SelectList(subrubros.OrderBy(e => e.Descripcion), "SubrubroID", "Descripcion");
            //var rubros = _context.Rubros.Where(e => e.Eliminado == false).ToList();
            //ViewBag.RubroID = new SelectList(rubros.OrderBy(e => e.Descripcion), "RubroID", "Descripcion");
            //return View();
            var rubros = _context.Rubros.Where(p => p.Eliminado == false).ToList();
            rubros.Add(new Rubro { RubroID = 0, Descripcion = "[RUBROS]" });
            ViewBag.RubroID = new SelectList(rubros.OrderBy(p => p.Descripcion), "RubroID", "Descripcion");

            List<SubRubro> subrubros = new List<SubRubro>();
            subrubros.Add(new SubRubro { SubrubroID = 0, Descripcion = "[SUBRUBROS]" });
            ViewBag.SubrubroID = new SelectList(subrubros.OrderBy(p => p.Descripcion), "SubrubroID", "Descripcion");
            return View();

        }

        public JsonResult BuscarArticulos()
        {
            var articulos = _context.Articulos.Include(e => e.SubRubro).Include(e => e.SubRubro.Rubro).ToList();
            List<ArticuloMostrar> listadoArticulos = new List<ArticuloMostrar>();
            var mapArticulo = articulos.Select(e => new ArticuloMostrar
            {
                ArticuloID = e.ArticuloID,
                Descripcion = e.Descripcion,
                SubrubroNombre = e.SubRubro.Descripcion,
                RubroNombre = e.SubRubro.Rubro.Descripcion,
                UltAct = DateTime.Now,
                UltActString = e.UltAct.ToString("dd/MM/yyyy"),
                PrecioCosto = e.PrecioCosto,
                PorcentajeGanancia = e.PorcentajeGanancia,
                PrecioVenta = e.PrecioVenta,
                SubrubroID = e.SubRubro.SubrubroID,
                RubroID = e.SubRubro.Rubro.RubroID,
                
                Eliminado = e.Eliminado,

            });


            return Json(mapArticulo);
        }

        public JsonResult GuardarArticulo(int ArticuloID, string Descripcion, decimal PrecioCosto, decimal PorcentajeGanancia, decimal PrecioVenta, int SubrubroID)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            bool resultado = true;

            if (!string.IsNullOrEmpty(Descripcion))
            {

                if (ArticuloID == 0)
                {
                    //CREA EL REGISTRO DE RUBRO
                    //PARA ESO CREAMOS UN OBJETO DE TIPO RUBRO CON LOS DATOS NECESARIOS
                    var ArticuloNew = new Articulo
                    {
                        Descripcion = Descripcion,
                        PrecioCosto = PrecioCosto,
                        PorcentajeGanancia = PorcentajeGanancia,
                        PrecioVenta = PrecioVenta,
                        SubrubroID = SubrubroID,

                    };
                    _context.Add(ArticuloNew);
                    _context.SaveChanges();
                }
                else
                {
                    //EDITA EL REGISTRO
                    //BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                    var articulo = _context.Articulos.Single(m => m.ArticuloID == ArticuloID);
                    //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                    articulo.Descripcion = Descripcion;
                    articulo.PrecioCosto = PrecioCosto;
                    articulo.PorcentajeGanancia = PorcentajeGanancia;
                    articulo.PrecioVenta = PrecioVenta;
                    articulo.SubrubroID = SubrubroID;
                    _context.SaveChanges();
                }

            }


            return Json(resultado);
        }

        public JsonResult EliminarArticulo(int ArticuloID, int Elimina)
        {
            bool resultado = true;

            var articulo = _context.Articulos.Find(ArticuloID);
            if (articulo != null)
            {
                if (Elimina == 0)
                {
                    articulo.Eliminado = false;
                }
                else
                {
                    articulo.Eliminado = true;

                }
                _context.SaveChanges();
            }

            return Json(resultado);
        }

        public JsonResult BuscarArticulo(int ArticuloID)
        {
            var articulo = _context.Articulos.FirstOrDefault(m => m.ArticuloID == ArticuloID);

            return Json(articulo);
        }
    }
}
