using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DbStuffz.Models;
using Oracle.ManagedDataAccess.Client;

namespace DbStuffz
{
    public class DbStuffzContext : DbContext
    {
        public IDbSet<InModel> Ins { get; set; }
        public IDbSet<OutModel> Outs { get; set; }

        public DbStuffzContext()
            :
            base(new OracleConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString), true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("OnModelCreating");
            modelBuilder.HasDefaultSchema("BATCH");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}