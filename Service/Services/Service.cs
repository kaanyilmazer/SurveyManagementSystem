using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Results;
using Service.Mapping;
using Core.Dtos;

namespace Service.Services
{
    public class Service<T,TDto> : IService<T,TDto> where T : class  where TDto : class
    {
        protected readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async virtual Task<IDataResult<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<T>(entity);
            await _repository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);
            return new SuccessDataResult<TDto>(newDto);
        }

        public async virtual Task<IDataResult<bool>> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return new SuccessDataResult<bool>( await _repository.AnyAsync(expression));
        }

        public async virtual Task<IDataResult<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = ObjectMapper.Mapper.Map<List<TDto>>(await _repository.GetAllAsync());
            return new SuccessDataResult<IEnumerable<TDto>>(entities);
        }

        public async virtual Task<IDataResult<TDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<TDto>(ObjectMapper.Mapper.Map<TDto>(entity));
        }

        public async virtual Task<IResult> RemoveAsync( int id)
        {
            var isExistEntity = await _repository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return new ErrorDataResult<NoContentDto>();
            }
            _repository.Remove(isExistEntity);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<NoContentDto>();
        }

        public async virtual Task<IResult> UpdateAsync(TDto entity)
        {
            var updatedEntity = ObjectMapper.Mapper.Map<T>(entity);
            _repository.Update(updatedEntity);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<NoContentDto>();
        }

        public async virtual Task<IDataResult<IQueryable<T>>> Where(Expression<Func<T, bool>> predicate)
        {
            var list = _repository.Where(predicate);

            return new SuccessDataResult<IQueryable<T>>(list);
        }
    }
}
