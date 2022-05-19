using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppRubrossss.Models;

namespace AppRubrossss.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<SubRubro> SubRubros { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
    }
}