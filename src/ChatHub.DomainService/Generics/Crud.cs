using ChatHub.Domain;
using ChatHub.DomainService.EFContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.DomainService.Generics
{
    public class Crud<T> : ICrud<T> where T : BaseEntity
    {
        private readonly ChatHubEntities dbContext;

        public Crud(ChatHubEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Create(T entity)
        {
            return dbContext.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            dbContext.Remove(entity);
        }

        public async Task Delete(object id)
        {
            T entity = await dbContext.FindAsync<T>(id);
            dbContext.Remove(entity);
        }

        public async Task<T> ReadAsync(object id)
        {
            return await dbContext.FindAsync<T>(id);
        }

        public void Update(T entity)
        {
            dbContext.Update(entity);
        }
    }
}
