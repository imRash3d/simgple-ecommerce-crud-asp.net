using SimpleEcommerce.Dtos;
using SimpleEcommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.Contracts
{
    public interface IUserService
    {



        List<User> Getusers();

      

        User Register(User user);
        User Login(string userName);
    }
}
