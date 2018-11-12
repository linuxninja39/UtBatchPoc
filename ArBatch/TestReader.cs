using System.Collections.Generic;
using DbStuffz.Models;
using DbStuffz.Repositories;
using NLog;
using Summer.Batch.Infrastructure.Item;

namespace ArBatch
{
    public class TestReader : IItemReader<InModel>
    {
        private readonly IInRepository _inRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private IList<InModel> _rows;

        public TestReader(IInRepository inRepository)
        {
            _inRepository = inRepository;
        }

        public InModel Read()
        {
            Logger.Debug("reading");
            if (_rows == null)
            {
                _rows = _inRepository.GetIns();
            }

            if (_rows.Count < 1)
            {
                return null;
            }

            var t = _rows[0];
            _rows.RemoveAt(0);
            return t;
        }
    }
}