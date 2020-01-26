using AutoMapper;
using SaveTimeCore.AbstractModels;
using System.Collections.Generic;

namespace SaveTimeCore.Services
{
    public class Service<TEntity, TDto, TResource> : IService<TEntity, TDto, TResource> where TDto : class where TResource : class where TEntity : class
    {
        protected readonly IRepository<TEntity, TDto> _repository;
        protected readonly IMapper _mapper;
        public Service(IRepository<TEntity, TDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            _repository.Add(entity);
        }

        public void Delete(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            _repository.Delete(entity);
        }

        public void Delete(int? id)
        {
            _repository.Delete(id);
        }

        public TResource Get(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            var dto = _repository.Get(entity);
            var resource = _mapper.Map<TResource>(dto);
            return resource;
        }

        public TResource Get(int? id)
        {
            var dto = _repository.Get(id);
            var resource = _mapper.Map<TResource>(dto);
            return resource;
        }

        public IEnumerable<TResource> GetAll()
        {
            var dtos = _repository.GetAll();
            var resources = _mapper.Map<IEnumerable<TResource>>(dtos);
            return resources;
        }

        public void Update(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            _repository.Update(entity);
        }
    }
}
