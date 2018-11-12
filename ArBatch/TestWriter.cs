using System.Collections.Generic;
using System.Linq;
using DbStuffz.Models;
using DbStuffz.Repositories;
using NLog;
using Summer.Batch.Infrastructure.Item;

namespace ArBatch
{
    public class TestWriter: IItemWriter<OutModel>
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IOutRepository _outRepository;

        public TestWriter(IOutRepository outRepository)
        {
            _outRepository = outRepository;
        }

        public void Write(IList<OutModel> items)
        {
            Logger.Debug("writting");
            _outRepository.SaveOuts(items);
        }
    }
}