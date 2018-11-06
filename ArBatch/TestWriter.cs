using System.Collections.Generic;
using NLog;
using Summer.Batch.Infrastructure.Item;

namespace ArBatch
{
    public class TestWriter: IItemWriter<Class1>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public void Write(IList<Class1> items)
        {
            Logger.Debug("writting");
        }
    }
}