using System.ComponentModel.DataAnnotations;

namespace AppRubrossss.Models
{
    public class Rubro
    {
        [Key]
        public int RubroID { get; set; }
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
        public virtual ICollection<SubRubro> SubRubros { get; set; }
    }
}
