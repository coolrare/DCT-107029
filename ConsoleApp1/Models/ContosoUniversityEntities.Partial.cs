namespace ConsoleApp1.Models
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class ContosoUniversityEntities : DbContext
    {
        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    entry.CurrentValues.SetValues(new { ModifiedOn = DateTime.Now });
                }
            }

            return base.SaveChanges();
        }
    }
}