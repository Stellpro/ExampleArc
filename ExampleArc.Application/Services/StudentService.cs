using ExamleArc.Db;
using ExamleArc.Db.Models;
using ExamleArc.Db.Repo;
using ExampleArc.Core.Abstraction;
using ExampleArc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExampleArc.Application.Services
{
    public class StudentService: IStudentService
    {
        private ExampleArcDbContext _dbContext;
        private StudentRepository repo;
        public StudentService(ExampleArcDbContext context)
        {
            _dbContext = context;
            repo = new StudentRepository(context);
        }
        public async Task<int> Delete(int id)
        {
            var x = repo.FindById(id);
            if (x == null)
            {
                throw new Exception();
            }
           await repo.Delete(x);
           return id;
        }
        private static Student Convert(StudentEntity r)
        {
            return new Student
            {
                StudentId = r.StudentId,
                Name = r.Name,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Age = r.Age,
            };
        }
        public async Task<Student> Create(Student r)
        {
            var p = new StudentEntity
            {
                StudentId = r.StudentId,
                Name = r.Name,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Age = r.Age,
            };
            var newItem = await repo.Create(p);
            return  Convert(newItem);
        }
        public async Task<Student> Update(Student r,int id)
        {
            var x = repo.FindById(id);

            if (x == null)
            {
                throw new Exception ();
            }
            x.Name = r.Name;
            x.FirstName = r.FirstName;
            x.LastName = r.LastName;
            x.Age = r.Age;
           
            var newItem = await repo.Update(x);
            return Convert(newItem);
        }
        public async Task<List<Student>> GetAll()
        {
            var result = await repo.Get();
            var list = result.Select(r => Convert(r)).ToList();
            return list;
        }
    }
}
