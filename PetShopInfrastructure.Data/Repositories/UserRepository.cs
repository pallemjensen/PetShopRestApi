using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly PetshopContext _ctx;

        public UserRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> GetAll()
        {
            return _ctx.Users;
        }      

        public User GetUserById(long userId)
        {
            return _ctx.Users.FirstOrDefault(usr => usr.UserId == userId);
        }

        public void AddUser(User entity)
        {
            _ctx.Users.Add(entity);
            _ctx.SaveChanges();
        }

        public void EditUser(User entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void RemoveUser(long id)
        {
            var item = _ctx.Users.FirstOrDefault(usr => usr.UserId == id);
            _ctx.Users.Remove(item);
            _ctx.SaveChanges();
        }
    }
}
