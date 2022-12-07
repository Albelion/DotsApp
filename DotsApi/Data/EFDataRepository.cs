using System.Linq;
using System.Threading.Tasks;
using DotsApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DotsApi.Data{
    public class EFDataRepository : IDataRepository
    {
        private DotsAppDbContext _context;
        public EFDataRepository(DotsAppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Dot> Dots => _context.Dots.Include(c=>c.Comments);

        public IQueryable<Comment> Comments => _context.Comments.Include(d=>d.Dot);

        public async Task DeleteDotWithComments(Dot d)
        {
            _context.Dots.Remove(d);
            await _context.SaveChangesAsync();
        }
    }
}