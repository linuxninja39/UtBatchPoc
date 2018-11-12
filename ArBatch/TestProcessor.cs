using System.Linq;
using System.Linq.Expressions;
using DbStuffz.Models;
using NLog;
using Summer.Batch.Infrastructure.Item;

namespace ArBatch
{
    public class TestProcessor: IItemProcessor<InModel, OutModel>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public OutModel Process(InModel item)
        {
            Logger.Debug("processing");
            var outModel = new OutModel
            {
                Name = item.Name,
                Reverse = item.Name.Reverse().ToString()
            };
            return outModel;
        }
    }
}