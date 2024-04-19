using Microsoft.EntityFrameworkCore;
using Persons.Application.Common.Exceptions;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Domain.Base;
using Persons.Infrastructure.Persistence.Context;
using System.Reflection;

namespace Persons.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class, IBase
    {
        protected readonly IDbContext _context;
        protected readonly DbSet<TEntity> _db;

        public BaseRepository(IDbContext context)
        {
            _context = context;
            _db = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Query()
        {
            return _db.AsQueryable().OrderByDescending(x => x.CreatedDate);
        }
        public virtual async Task<TEntity> Get(Guid id)
        {
            var entity = await Query().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity is null) throw new NotFoundException(typeof(TEntity).Name, id);

            return entity;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await _db.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            var _entity = await Get(entity.Id);
            Type type = typeof(TEntity);
            PropertyInfo[] propertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in propertyInfo)
            {
                var fieldValue = item.GetValue(entity);
                if (fieldValue != null)
                {
                    item.SetValue(_entity, fieldValue);
                }
            }
            await _context.SaveChangesAsync();
            return _entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await Get(id);

            var result = _db.Remove(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }

}
