namespace Academiq.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Academiq.Models.AcademiqDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Academiq.Models.AcademiqDbContext";
        }

        protected override void Seed(Academiq.Models.AcademiqDBEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
