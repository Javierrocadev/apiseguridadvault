using apiseguridadvault.Models;
using Microsoft.EntityFrameworkCore;

namespace apiseguridadvault.Data
{
    public class EmpleadoContext : DbContext
    {
        public EmpleadoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
