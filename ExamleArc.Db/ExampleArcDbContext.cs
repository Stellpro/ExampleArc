using ExamleArc.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamleArc.Db
{
    public class ExampleArcDbContext : DbContext
    {
        public ExampleArcDbContext(DbContextOptions<ExampleArcDbContext> options)
         : base(options)
        {
        }
      public DbSet<StudentEntity> StudentDbContext { get; set; }
    }
}
