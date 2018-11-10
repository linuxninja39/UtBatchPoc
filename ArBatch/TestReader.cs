using NLog;
using Summer.Batch.Infrastructure.Item;

namespace ArBatch
{
    public class TestReader : IItemReader<Class1>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private int _counter = 0;

        public Class1 Read()
        {
            Logger.Debug("reading");
            if (_counter < 10)
            {
                _counter++;
                return new Class1();
            }
            else
            {
                return null;
            }
        }
    }
}