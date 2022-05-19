﻿using System.ComponentModel.DataAnnotations;

namespace AppRubrossss.Models
{
    public class SubRubro
    {
        [Key]
        public int SubrubroID { get; set; }
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
        public int RubroID { get; set; }

        public virtual Rubro Rubro { get; set; }
        public virtual ICollection<Articulo> Articulos { get; set; }
    
    
    }
    public class SubRubroMostrar
    {
        public int SubrubroID { get; set; }
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
        public int RubroID { get; set; }

        public string RubroDescripcion { get; set; }
    }
}
