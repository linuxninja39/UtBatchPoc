using System.Configuration;
using DbStuffz;
using DbStuffz.Models;
using DbStuffz.Repositories;
using Microsoft.Practices.Unity;
using NLog;
using Summer.Batch.Core.Repository.Dao;
using Summer.Batch.Core.Unity;
using Summer.Batch.Infrastructure.Item;

namespace ArBatch
{
    public class ArBatchUnityLoader : UnityLoader
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Registers the artifacts required to execute the steps (tasklets, readers, writers, etc.)
        /// </summary>
        /// <param name="container">the unity container to use for registrations</param>
        public override void LoadArtifacts(IUnityContainer container)
        {
            //Connection string
            var writerConnectionString = ConfigurationManager.ConnectionStrings["Default"];
            container.RegisterSingleton<DbStuffzContext>();
            container.RegisterSingleton<IInRepository, InRepository>();
            container.RegisterSingleton<IOutRepository, OutRepository>();
            Logger.Debug("registering reader");
            container.StepScopeRegistration<IItemReader<InModel>, TestReader>("FlatFileReader/FlatFileReader").Register();
            Logger.Debug("registering processor");
            container.RegisterStepScope<IItemProcessor<InModel, OutModel>, TestProcessor>("FlatFileReader/Processor");
            Logger.Debug("registering writer");
            container.StepScopeRegistration<IItemWriter<OutModel>, TestWriter>("FlatFileReader/DatabaseWriter").Register();
        }
    }
}