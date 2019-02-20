using ChatHub.Domain;
using ChatHub.DomainService.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.DomainService
{
    public abstract class BaseService<TInput, TOutput> : IBaseService<TOutput> where TInput : BaseEntity where TOutput : BaseOutput
    {
        private readonly ChatHubEntities dbContext;

        protected BaseService(ChatHubEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        protected abstract TInput ToEntity(TOutput output);
        protected abstract TOutput ToOutput(TInput entity);

        public virtual TOutput Create(TOutput value)
        {
            TInput entity = ToEntity(value);
            entity = dbContext.Set<TInput>().Add(entity).Entity;

            return ToOutput(entity);
        }

        public virtual void Delete(TOutput value)
        {
            TInput entity = ToEntity(value);
            dbContext.Remove(entity);
        }

        public virtual async Task Delete(object id)
        {
            TInput entity = await dbContext.FindAsync<TInput>(id);
            dbContext.Remove(entity);
        }

        public virtual async Task<TOutput> ReadAsync(object id)
        {
            var entity = await dbContext.FindAsync<TInput>(id);
            return ToOutput(entity);
        }

        public virtual void Update(TOutput value)
        {
            TInput entity = ToEntity(value);
            dbContext.Update(entity);
        }
    }
}
