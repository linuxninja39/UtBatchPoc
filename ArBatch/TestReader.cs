using NLog;
using Summer.Batch.Infrastructure.Item;

namespace ArBatch
{
    public class TestReader: IItemReader<Class1>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public Class1 Read()
        {
            Logger.Debug("reading");
            return new Class1();
        }
    }
}