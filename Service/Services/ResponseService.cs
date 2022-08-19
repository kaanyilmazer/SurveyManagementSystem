using Core.Dtos;
using Core.Model;
using Core.Repositories;
using Core.Results;
using Core.Services;
using Core.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ResponseService : Service<Response, ResponsesDto>, IResponseService
    {
        private readonly IValidator<ResponsesDto> _responseValidator;
        public ResponseService(IGenericRepository<Response> repository, IUnitOfWork unitOfWork, IValidator<ResponsesDto> responseValidator) : base(repository, unitOfWork)
        {
            _responseValidator = responseValidator;
        }

        public override async Task<IDataResult<ResponsesDto>> AddAsync(ResponsesDto entity)
        {
            var validationResults = await _responseValidator.ValidateAsync(entity);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<ResponsesDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }
            return await base.AddAsync(entity);
        }

        public override async Task<IResult> UpdateAsync(ResponsesDto entity)
        {
            var validationResults = await _responseValidator.ValidateAsync(entity);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<ResponsesDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }

            return await base.UpdateAsync(entity);
        }
    }
}
