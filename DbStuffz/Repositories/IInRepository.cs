using System.Collections.Generic;
using DbStuffz.Models;

namespace DbStuffz.Repositories
{
    public interface IInRepository
    {
        IList<InModel> GetIns();
    }
}