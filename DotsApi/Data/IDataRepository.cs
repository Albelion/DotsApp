using DotsApi.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotsApi.Data{
    public interface IDataRepository{
        IQueryable<Dot> Dots{get;}
        IQueryable<Comment> Comments { get;}
        Task DeleteDotWithComments(Dot d);
    }
}