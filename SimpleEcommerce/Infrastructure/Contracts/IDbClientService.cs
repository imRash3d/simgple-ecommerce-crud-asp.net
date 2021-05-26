using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Contracts
{
   public interface IDbClientService
    {
       IMongoCollection<T> GetCollection<T>( string collectionName);

    }
}
