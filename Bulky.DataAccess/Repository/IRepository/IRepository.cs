using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); //to fetch all the categories and other data
        T Get(Expression<Func<T, bool>> filter); //to fetch one single data, passed a lambda expression as remember when we used FirstOrDefault method in _db.Categories.FirstOrDefault(p=>p==p.Id)
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
