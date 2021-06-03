using MongoDB.Driver;
using SimpleEcommerce.Dtos;
using SimpleEcommerce.Entities;
using SimpleEcommerce.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Services
{
   
    public class UserService : IUserService
    { private readonly IMongoCollection<User> userCollection;


        public UserService(IDbClientService dbClientService, IConfigurationService configurationService)
        {
            userCollection = dbClientService.GetCollection<User>(configurationService.GetAppsettingValueByKey("UserCollectionName"));

            

        }
        
        public List<User> Getusers()
        {
            return userCollection.Find(x => true).ToList();
        }

        

      

        public User Login(string userName)
        {
            return userCollection.Find(x => x.UserName == userName).FirstOrDefault();
        }

        public User Register(User user)
        {
            userCollection.InsertOneAsync(user);
            return user;
        }
    }
}
