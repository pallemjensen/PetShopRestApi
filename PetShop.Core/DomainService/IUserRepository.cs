using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IUserRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetUserById(long userId);
        void AddUser(T entity);
        void EditUser(T entity);
        void RemoveUser(long id);
    }
}
