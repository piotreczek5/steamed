using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Generics
{
    public interface IBaseCrudService<TDto>
    {
        Task<TDto> GetById(int id);
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> Add(TDto game);
        Task<TDto> Update(TDto game);
        Task Remove(int id);
    }
}