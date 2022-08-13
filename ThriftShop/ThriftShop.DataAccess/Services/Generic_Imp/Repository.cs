﻿using ThriftShop.DataAccess.Repository.IRepository.GenericInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThriftShop.DataAccess.Data;

namespace ThriftShop.DataAccess.Repository.Services.Generic_Imp
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

      


        //add range
        public async Task<List<T>> AddRange(List<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities;
        }

        //includeProp - "Category,CoverType"
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter=null,string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter).AsNoTracking();
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter).AsNoTracking();
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
