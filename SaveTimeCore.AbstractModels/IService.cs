using System.Collections.Generic;

namespace SaveTimeCore.AbstractModels
{
    public interface IService<TEntity, TDto, TResource> where TDto : class where TResource : class where TEntity : class
    {
        void Add(TDto item);
        void Delete(TDto item);
        void Delete(int? id);
        void Update(TDto item);
        IEnumerable<TResource> GetAll();
        TResource Get(TDto item);
        TResource Get(int? id);
    }
}
