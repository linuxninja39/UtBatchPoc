using System.Collections.Generic;
using DbStuffz.Models;

namespace DbStuffz.Repositories
{
    public interface IOutRepository
    {
        void SaveOut(OutModel outModel);
        void SaveOuts(IEnumerable<OutModel> outModels);
    }
}