using AutoMapper;
using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generics
{
    public abstract class BaseDbContextCrudService<TEntity, TDto> : IBaseCrudService<TDto>
        where TEntity : class
        where TDto : class
    {
        private DbContext _context;
        private readonly IMapper _mapper;

        public BaseDbContextCrudService(DbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TDto> Add(TDto game)
        {
            TEntity entityObject = _mapper.Map<TDto, TEntity>(game);

            await _context.Set<TEntity>().AddAsync(entityObject);
            await _context.SaveChangesAsync();

            TDto dtoObject = _mapper.Map<TEntity, TDto>(entityObject);
            return dtoObject;
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var entitySet = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            var mappedEntitySet = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entitySet);
            return mappedEntitySet;
        }

        public async virtual Task<TDto> GetById(int id)
        {
            var entityToFind = await FindById(id);
            return _mapper.Map<TEntity, TDto>(entityToFind);
        }

        public async Task Remove(int id)
        {
            var entityToFind = await FindById(id);
            _context.Set<TEntity>().Remove(entityToFind);
            await _context.SaveChangesAsync();
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

            var entityFound = await _context.Set<TEntity>().SingleOrDefaultAsync(e => (int)idProperty.GetValue(e) == id);
            if (entityFound == null)
            {
                throw new EntityNotFoundException($"Entity of type : {typeof(TEntity).Name} with Id : {id} could not be found.");
            }

            return entityFound;
        }

    }
}
