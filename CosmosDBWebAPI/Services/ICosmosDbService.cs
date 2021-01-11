using CosmosDBWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBWebAPI.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Student>> GetStudentsAsync(string query);

        Task AddStudentAsync(Student student);

        Task UpdateStudentAsync(string id, Student student);

        Task DeleteStudentAsync(string id);

    }
}
