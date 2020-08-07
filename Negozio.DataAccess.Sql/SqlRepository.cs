using Microsoft.EntityFrameworkCore;
using Negozio.Core.Contracts;
using Negozio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negozio.DataAccess.Sql
{
    public class SqlRepository<T> : IRepositorio<T> where T : BaseEntita
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SqlRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var t = Find(Id);
            if (context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }
            dbSet.Remove(t);
        }

        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
    
