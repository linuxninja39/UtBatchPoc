using System.Configuration;
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
            Logger.Debug("registering reader");
            container.StepScopeRegistration<IItemReader<Class1>, TestReader>("FlatFileReader/FlatFileReader").Register();
            Logger.Debug("registering processor");
            container.RegisterStepScope<IItemProcessor<Class1, Class1>, TestProcessor>("FlatFileReader/Processor");
            Logger.Debug("registering writer");
            container.StepScopeRegistration<IItemWriter<Class1>, TestWriter>("FlatFileReader/DatabaseWriter").Register();

            // Reader - FlatFileReader/FlatFileReader
            /*
            container.StepScopeRegistration<IItemReader<object>, FlatFileItemReader<object>>("FlatFileReader/FlatFileReader")
                .Property("Resource").Value(inputFileResource)
                .Property("Encoding").Value(Encoding.GetEncoding("UTF-8"))
                .Property("LineMapper").Reference<ILineMapper<object>>("FlatFileReader/FlatFileReader/LineMapper")
                .Register();
    
            // Line mapper
            container.StepScopeRegistration<ILineMapper<object>, DefaultLineMapper<object>>("FlatFileReader/FlatFileReader/LineMapper")
                .Property("Tokenizer").Reference<ILineTokenizer>("FlatFileReader/FlatFileReader/Tokenizer")
                .Property("FieldSetMapper").Reference<IFieldSetMapper<object>>("FlatFileReader/FlatFileReader/FieldSetMapper")
                .Register();
    
            // Tokenizer
            container.StepScopeRegistration<ILineTokenizer, DelimitedLineTokenizer>("FlatFileReader/FlatFileReader/Tokenizer")
                .Property("Delimiter").Value(";")
                .Register();
    
            // Field set mapper
            container.RegisterStepScope<IFieldSetMapper<object>, FlatFileRecordMapper>("FlatFileReader/FlatFileReader/FieldSetMapper");
    
            // Processor - FlatFileReader/Processor
            container.RegisterStepScope<IItemProcessor<object, object>,FlatFileRecordProcessor >("FlatFileReader/Processor");
    
            // Writer - FlatFileReader/DatabaseWriter
            container.StepScopeRegistration<IItemWriter<object>, DatabaseBatchItemWriter<object>>("FlatFileReader/DatabaseWriter")
                .Property("ConnectionString").Instance(writerConnectionstring)
                .Property("Query").Value("INSERT INTO BA_FLATFILE_READER_TABLE (CODE,NAME,DESCRIPTION,DATE) VALUES (:code,:name,:description,:date)")
                .Property("DbParameterSourceProvider").Reference<PropertyParameterSourceProvider<object>>()
                .Register();
                */
        }
    }
}