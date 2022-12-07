using Microsoft.EntityFrameworkCore;
using DotsApi.Data.Models;

namespace DotsApi.Data{
    public class DotsAppDbContext:DbContext{
        public DotsAppDbContext(DbContextOptions<DotsAppDbContext> options):base(options){}
            public DbSet<Dot> Dots => Set<Dot>();
            public DbSet<Comment> Comments =>Set<Comment>();
        }
}