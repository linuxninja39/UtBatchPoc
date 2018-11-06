using NLog;
using Summer.Batch.Infrastructure.Item;

namespace ArBatch
{
    public class TestProcessor: IItemProcessor<Class1, Class1>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public Class1 Process(Class1 item)
        {
            Logger.Debug("processing");
            return new Class1();
        }
    }
}