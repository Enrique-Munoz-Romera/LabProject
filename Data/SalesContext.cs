using Microsoft.EntityFrameworkCore;

namespace LabProject.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }

        #region BBDD
        public SalesContext() { }

        //Configuracion del contexto para la inserccion
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Configura la cadena de conexión a tu base de datos
        //    optionsBuilder.UseSqlServer("Data Source=LOCALHOST;Initial Catalog=SalesContext;Integrated Security=True;Trust Server Certificate=True");
        //}
        #endregion
        public DbSet<LabProject.Models.Sales.Order> Order { get; set; } = default!;

        public DbSet<LabProject.Models.Sales.OrderDetail> OrderDetail { get; set; } = default!;
    }
}
