using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDBWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CosmosDBWebAPI.Services;
using Microsoft.Azure.Cosmos;

namespace CosmosDBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;
        public StudentController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        // GET api/Student
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _cosmosDbService.GetStudentsAsync("SELECT * FROM c");
        }

        // POST api/Student
        [HttpPost]
        public async void Post([FromBody] Student student)
        {
            student.Id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddStudentAsync(student);
        }

        // PUT api/Student/5
        [HttpPut("{id}")]
        public async void Put(string id, [FromBody] Student student)
        {
            await _cosmosDbService.UpdateStudentAsync(id, student);
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {

            await _cosmosDbService.DeleteStudentAsync(id);            
        }


    }
}
