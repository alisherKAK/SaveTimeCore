using System.Collections.Generic;

namespace SaveTimeCore.AbstractModels
{
    public interface IRepository<TEntity, TDto> where TEntity : class where TDto : class
    {
        void Add(TEntity item);
        void Delete(TEntity item);
        void Delete(int? id);
        void Update(TEntity item);
        IEnumerable<TDto> GetAll();
        TDto Get(TEntity item);
        TDto Get(int? id);
    }
}
