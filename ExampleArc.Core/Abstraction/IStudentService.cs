using ExampleArc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleArc.Core.Abstraction
{
    public interface IStudentService
    {
        Task<int> Delete(int id);

        Task<Student> Create(Student r);

        Task<Student> Update(Student r,int id);

        Task<List<Student>> GetAll();

    }
}
