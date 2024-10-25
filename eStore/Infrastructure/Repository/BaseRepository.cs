using Application.Helpers;
using Domain.Common;
using Domain.Entities;
using eStore.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : GlobalVariables, IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _entities;
        protected ApplicationDbContext DbContext => _dbContext;

        public BaseRepository(ApplicationDbContext dbContext,IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("context");
            _entities = dbContext.Set<T>();
        }

        public async Task<ResponseResult> GetAll()
        {
            var result = new ResponseResult();
            try
            {
                var entities = await _entities.ToListAsync();
                result.Data = entities;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = Utilities.MakeExceptionMessage(ex);
                result.Success = false;
            }
            return result;
        }

        public IQueryable<T> AsQueryable()
        {
            var query = _entities.AsQueryable();
            return query;
        }

        public async Task<ResponseResult> Create(T entity)
        {
            var result = new ResponseResult();
            if(entity != null)
            {
                _entities.Add(entity);
                result.Data = await SaveChanges(result) ? entity : null;
            }
            return result;
        }

        public void EntryCollection(T entity, Expression<Func<T, IEnumerable<dynamic>>> entityCollection)
        {
            _dbContext.Entry(entity).Collection(entityCollection).Load();
        }

        public void EntryReference(T entity, Expression<Func<T, dynamic>> entityReference)
        {
            _dbContext.Entry(entity).Reference(entityReference).Load();
        }

        public async Task<T> GetById(long id)
        {
            var entity = await _entities.FindAsync(id);
            return entity;
        }

        public async Task<ResponseResult> Insert(T entity)
        {
            var result = new ResponseResult();
            if( entity != null)
            {
                _entities.Add(entity);
                result.Data = await SaveChanges(result) ? entity : null;
            }
            return result;
        }

        public async Task<ResponseResult> Remove(long id)
        {
            var result = new ResponseResult();
            T entity = await GetById(id);
            if(entity!= null)
            {
                _entities.Remove(entity);
                await SaveChanges(result);
            }
            return result;
        }

        public async Task<ResponseResult> RemoveAll(IEnumerable<T> entities)
        {
            var result = new ResponseResult();
            _entities.RemoveRange(entities);
            await SaveChanges(result);
            return result;
        }

        public async Task<bool> SaveChanges(ResponseResult result)
        {
            try
            {
                result.Success = await _dbContext.SaveChangesAsync() >= 0;
            }
            catch (Exception ex)
            {
                var message = Utilities.MakeExceptionMessage(ex);
                result.Success = true;
                result.Message = message;
            }
            return result.Success;
        }

        public async Task<ResponseResult> Update(T entity)
        {
            var result = new ResponseResult();
            if(entity != null)
            {
                T data = await GetById(entity.Id);
                if(data != null)
                {
                    _dbContext.Entry(data).CurrentValues.SetValues(entity);
                    result.Data = await SaveChanges(result) ? entity : null;
                }
            }
            return result;
        }

        public async Task<ResponseResult> UpdateMany(IEnumerable<T> entities)
        {
            var result = new ResponseResult();
            if(entities.Any())
            {
                foreach (var entity in entities)
                {
                    T data = await GetById(entity.Id);
                    if(data != null)
                    {
                        _dbContext.Entry(data).CurrentValues.SetValues(entity);
                        result.Data = await SaveChanges(result) ? entity :null;
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> where)
        {
            return await Task.FromResult(_entities.Where(where).ToList());
        }
    }
}
