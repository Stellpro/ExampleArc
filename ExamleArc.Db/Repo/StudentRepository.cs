using ExamleArc.Db.Models;
using ExampleArc.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamleArc.Db.Repo
{
    public class StudentRepository : BaseRepository<StudentEntity>
    {
   
        public StudentRepository(ExampleArcDbContext context) : base(context)
        {
            
        }
        
        public override Task<StudentEntity> Create(StudentEntity p)
        {
            return base.Create(p);

        }

    }
}
