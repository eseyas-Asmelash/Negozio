using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negozio.Core.Models;

namespace Negozio.Core.Contracts
{
     public interface IRepositorio<T> where T : BaseEntita
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);

    }
}
