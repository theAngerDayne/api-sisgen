using api_sisgen.Models.BoletaElectronica;
using Microsoft.EntityFrameworkCore;

namespace api_sisgen.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options) { }

         public DbSet<Documento> Boletas{get;set;}
         public DbSet<Detalle> DetallesBoleta { get; set; }
        
    }
}