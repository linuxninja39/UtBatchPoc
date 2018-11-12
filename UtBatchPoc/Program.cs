using System;
using System.Configuration;
using System.Data.Entity;
using ArBatch;
using DbStuffz;
using DbStuffz.Models;
using Oracle.ManagedDataAccess.Client;
using Summer.Batch.Core;

namespace UtBatchPoc
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var configurator = new ArBatchJobConfig();
            var job = configurator.GetXmlJob();
            var jobExecution = JobStarter.Start(job, new ArBatchUnityLoader());
            /*
            */
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbStuffzContext>());

            var con = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            Console.WriteLine("connection string");
            Console.WriteLine(con);
            /*
            using (var db = )
            {
                var in1 = new InModel {Name = "joe"};

                db.Ins.Add(in1);
                db.SaveChanges();
            }
            */
        }
    }
}