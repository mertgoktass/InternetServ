using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Core.DataAccess
{
    public interface IEntityRepository<TEntity>
    {
        void Delete(TEntity entity);
        int Create(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter , params Expression<Func<TEntity, object>>[] includeProperties);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null , params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
