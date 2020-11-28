using AutoMapper;
using Core.Generics;
using MongoDB.Driver;
using Steamed.Core.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steamed.Core.Generic
{
    public abstract class BaseDbMongoCollectionCrudService<TEntity, TDto> : IBaseCrudService<TDto>
    {
        private IMongoCollection<TEntity>  _collection ;
        private readonly IMapper _mapper;

        public BaseDbMongoCollectionCrudService(IMongoCollection<TEntity> collection, IMapper mapper)
        {
            _collection = collection;
            _mapper = mapper;
        }

        public async Task<TDto> Add(TDto game)
        {
            TEntity entityObject = _mapper.Map<TDto, TEntity>(game);

            await _collection.InsertOneAsync(entityObject);

            TDto dtoObject = _mapper.Map<TEntity, TDto>(entityObject);

            return dtoObject;
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            try
            {
                var entitySet = await _collection.FindAsync(item => true);
                var mappedEntitySet = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entitySet.ToList());
                return mappedEntitySet;
            }
            catch (FormatException ex)
            {
                throw new PortalInternalServerErrorException($"Could not format data for DTO: {typeof(TDto).Name}. Message: {ex.Message}");
            }
            
        }

        public async virtual Task<TDto> GetById(int id)
        {
            var entityToFind = await FindById(id);
            return _mapper.Map<TEntity, TDto>(entityToFind);
        }

        public async Task Remove(int id)
        {
            var entityToFind = await FindById(id);

            var idProperty = typeof(TEntity).GetProperty("Id");
            int entityToFindId = (int)idProperty.GetValue(entityToFind);
            await _collection.DeleteOneAsync(ent =>(int)idProperty.GetValue(ent) == entityToFindId);
        }

        public Task<TDto> Update(TDto game)
        {
            throw new NotImplementedException();
        }

        private async Task<TEntity> FindById(int id)
        {
            var type = typeof(TEntity);

            var idProperty = type.GetProperty("Id");
            if (idProperty == null)
            {
                throw new EntityDoesNotHaveColumnDefinedException($"Entity of type : {typeof(TEntity).Name} has no Id column defined.");
            }

            var entityFound = await 
                    (await _collection.FindAsync(e => (int)idProperty.GetValue(e) == id)).SingleOrDefaultAsync();

            if (entityFound == null)
            {
                throw new EntityNotFoundException($"Entity of type : {typeof(TEntity).Name} with Id : {id} could not be found.");
            }

            return entityFound;
        }
    }
}
