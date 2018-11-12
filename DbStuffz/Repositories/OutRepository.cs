using System.Collections.Generic;
using System.Linq;
using DbStuffz.Models;

namespace DbStuffz.Repositories
{
    public class OutRepository: IOutRepository
    {
        private readonly DbStuffzContext _context;

        public OutRepository(DbStuffzContext context)
        {
            _context = context;
        }


        public void SaveOut(OutModel outModel)
        {
            _context.Outs.Add(outModel);
            _context.SaveChanges();
        }

        public void SaveOuts(IEnumerable<OutModel> outModels)
        {
            foreach (var model in outModels)
            {
                _context.Outs.Add(model);
            }

            _context.SaveChanges();
        }
    }
}