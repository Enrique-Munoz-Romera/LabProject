using Microsoft.EntityFrameworkCore;

namespace LabProject.Data
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions<CustomersContext> options)
            : base(options)
        {
        }

        #region BBDD
        //public CustomersContext()
        //{
        //}

        //Configuracion del contexto para la inserccion
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Configura la cadena de conexión a tu base de datos
        //    optionsBuilder.UseSqlServer("Data Source=LOCALHOST;Initial Catalog=CustomersContext;Integrated Security=True;Trust Server Certificate=True");
        //}
        #endregion
        public DbSet<LabProject.Models.Customers.Customer> Customer { get; set; } = default!;
    }
}
