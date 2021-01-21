using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
        where T:class,IEntity,new()

        //referance,Ientity,ve newlenebilen
    {

        T Get(Expression<Func<T,bool>> filter);
        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeExpressions);
        IList<T> GetList(Expression<Func<T, bool>> filter=null);
        List<T> GetList(Expression<Func<T, bool>> filter = null,params Expression<Func<T, object>>[] includeExpressions);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
