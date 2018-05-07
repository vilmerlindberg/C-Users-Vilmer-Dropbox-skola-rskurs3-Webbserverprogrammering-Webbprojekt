using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Webbprojekt.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Maträtt> Maträtter { get; set; }
        public DbSet<Kategori> Kategorier { get; set; }
    }
}