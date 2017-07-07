namespace MvcProjem.Migrations
{
    using System;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

     internal sealed class Configuration : DbMigrationsConfiguration<MvcProjem.Models.VeriTabanı>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MvcProjem.Models.VeriTabanı";
        }

        protected override void Seed(MvcProjem.Models.VeriTabanı context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
          
        }

    }
}
