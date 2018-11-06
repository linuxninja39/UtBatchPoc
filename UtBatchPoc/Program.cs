using ArBatch;
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
        }
    }
}