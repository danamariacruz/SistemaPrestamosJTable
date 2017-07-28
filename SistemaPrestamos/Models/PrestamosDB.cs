using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaPrestamos.Models
{
    public class PrestamosDB: DbContext 
    {
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Prestamo> prestar { get; set; }
    }
}