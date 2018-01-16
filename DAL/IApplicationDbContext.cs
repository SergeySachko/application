using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<SubStatus> SubStatuses { get; set; }

        DbSet<Product> Products { get; set; }       

        int SaveChanges();
    }
}
