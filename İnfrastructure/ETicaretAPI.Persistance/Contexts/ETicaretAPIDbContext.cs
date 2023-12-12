using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public  DbSet<Product>Products { get; set; }
        public  DbSet<Order>Orders { get; set; }
        public  DbSet<Customer>Customers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        { // ChangeTracker: Entityler üzerinden yapılan  değişikliklerin ya da eklenen  verinin  yakalanmasını sağlayan propertydir.Update Operasyonlarında
          // Track edilen verileri yakalayıp elde etmemizi sağlar.
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach(var data in datas)
            {
               _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow

                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
