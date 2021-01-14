using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions options)
               :base(options)
        {
            
        }

        // Mapeamos cada entidad para que sea accesible
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
