using ChatHub.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.DomainService.Generics
{
    public interface ICrud<T> where T : BaseEntity
    {
        T Create(T entity);

        Task<T> ReadAsync(object id);

        void Update(T entity);

        void Delete(T entity);

        Task Delete(object id);
    }
}
