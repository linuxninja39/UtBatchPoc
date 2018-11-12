using System.Collections.Generic;
using System.Linq;
using DbStuffz.Models;

namespace DbStuffz.Repositories
{
    public class InRepository: IInRepository
    {
        private readonly DbStuffzContext _context;
        
        public InRepository(DbStuffzContext context )
        {
            _context = context;
        }
        public IList<InModel> GetIns()
        {
            return _context.Ins.ToList();
        }
    }
}