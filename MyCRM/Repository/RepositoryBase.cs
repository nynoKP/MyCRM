using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using System.Linq.Expressions;
using System;
using System.Reflection;
using MyCRM.Models;
using MyCRM.Filters;

namespace MyCRM.Repository
{
    public class RepositoryBase<T> where T : class
    {
        public ApplicationDbContext context;

        public RepositoryBase(ApplicationDbContext repositoryContext)
        => context = repositoryContext;

        public IQueryable<T> FindAll() => context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => context.Set<T>()
            .Where(expression);

        public int Count() => context.Set<T>().Count();

        public void Create(T entity) => context.Set<T>().Add(entity);

        public void Update(T entity) => context.Set<T>().Update(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public void Save() => context.SaveChanges();
    }
}
