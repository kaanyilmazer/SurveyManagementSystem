
using AutoMapper;
using Core.Dtos;
using Core.Model;
using Core.Repositories;
using Core.Results;
using Core.Services;
using Core.UnitOfWorks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AnswerService: Service<Answer,AnswerDto> , IAnswerService
    {
        private readonly IValidator<AnswerDto> _answerValidator;
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IGenericRepository<Answer> repository, IUnitOfWork unitOfWork, IAnswerRepository answerRepository, IMapper mapper, IValidator<AnswerDto> answerValidator) : base(repository, unitOfWork,mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _answerValidator = answerValidator;
        }

        public override async Task<IDataResult<AnswerDto>> AddAsync(AnswerDto entity)
        {
            var validationResults = await _answerValidator.ValidateAsync(entity);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<AnswerDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }
            return await base.AddAsync(entity);
        }

        

        public override async Task<IResult> UpdateAsync(AnswerDto entity)
        {

            var validationResults = await _answerValidator.ValidateAsync(entity);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<AnswerDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }
            return await base.UpdateAsync(entity);
        }

        public async Task<DataResult<List<AnswerWithQuestionDto>>> GetAnswerWithQuestion()
        {
            var questions = await _answerRepository.GetAnswerWithQuestion();
            var questionsDto = _mapper.Map<List<AnswerWithQuestionDto>>(questions);
            return new SuccessDataResult<List<AnswerWithQuestionDto>>(questionsDto);
        }
    }
}
