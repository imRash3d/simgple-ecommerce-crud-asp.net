using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleEcommerce.Infrastructure.Contracts;
using SimpleEcommerce.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Services
{
    public class DbClientService : IDbClientService
    {
        private readonly IMongoDatabase database;

        public DbClientService(IConfigurationService configurationService)
        {
            var  mongoClient = new MongoClient(configurationService.GetAppsettingValueByKey("MongoUri"));
            database = mongoClient.GetDatabase(configurationService.GetAppsettingValueByKey("DatabaseName"));

        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
           return database.GetCollection<T>(collectionName);
        }
    }
}
