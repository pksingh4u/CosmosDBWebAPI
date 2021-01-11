using CosmosDBWebAPI.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBWebAPI.Services
{
    public class CosmosDbService : ICosmosDbService
    {

        private Container _container;

        public CosmosDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddStudentAsync(Student student)
        {
            await this._container.CreateItemAsync<Student>(student, new PartitionKey(student.Id));
        }

        public async Task DeleteStudentAsync(string id)
        {
            await this._container.DeleteItemAsync<Student>(id, new PartitionKey(id));             
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync(string query)
        {
            var qry = this._container.GetItemQueryIterator<Student>(new QueryDefinition(query));
            List<Student> results = new List<Student>();
            while (qry.HasMoreResults)
            {
                var response = await qry.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateStudentAsync(string id, Student student)
        {
            await this._container.UpsertItemAsync<Student>(student, new PartitionKey(id));
        }
    }
}
