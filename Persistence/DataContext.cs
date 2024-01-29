using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
   public class DataContext : DbContext
   {
      public DataContext(DbContextOptions options) : base(options)
      {
      }

      public DbSet<Candidate> Candidates { get; set; }
      public DbSet<Degree> Degrees { get; set; }
   }
}