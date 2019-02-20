using ChatHub.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.DomainService
{
    public interface IBaseService<T> where T : BaseOutput
    {
        T Create(T entity);

        Task<T> ReadAsync(object id);

        void Update(T entity);

        void Delete(T entity);
    }
}
