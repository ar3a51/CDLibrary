using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using CDLibrary.Common;
using CDLibraryDataLayer.Migrations;

namespace CDLibraryDataLayer
{
    public class CDLibraryContext : DbContext
    {
        private static CDLibraryContext context;
        private static Object sysObject = new object();
        public CDLibraryContext()
            : base("CDDatabaseContext")
        {
            this.Configuration.LazyLoadingEnabled = true;

            //Database.SetInitializer(new CreateDatabaseIfNotExists<CDLibraryContext>());
        }

        public DbSet<CD> CDs { set; get; }
        public DbSet<CDLoan> CDLoans { set; get; }
        public DbSet<Prospect> Prospects { set; get; }

        public static CDLibraryContext Context
        {
            get
            {
                lock(sysObject)
                { 
                    if (context == null)
                        context = new CDLibraryContext();
                }
                
                return context;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Add<IncludeMetadataConvention>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CDLibraryContext, Configuration>());
            modelBuilder.Entity<CDLoan>().HasKey(e => new { e.CDid, e.prospectId });

            base.OnModelCreating(modelBuilder);
        }



    }

    
}
