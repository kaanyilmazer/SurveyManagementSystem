using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<T, TDto> where T : class where TDto : class
    {
        Task<IDataResult<TDto>> GetByIdAsync(int id);
        Task<IDataResult<IEnumerable<TDto>>> GetAllAsync();
        Task<IDataResult<IQueryable<T>>> Where(Expression<Func<T, bool>> predicate);
        Task<IDataResult<bool>> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IDataResult<TDto>> AddAsync(TDto entity);
        Task<IResult> UpdateAsync(TDto entity);
        Task<IResult> RemoveAsync( int id);
    }
}
