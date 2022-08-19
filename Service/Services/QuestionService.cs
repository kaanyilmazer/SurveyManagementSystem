using AutoMapper;
using AutoMapper.Internal.Mappers;
using Core.Dtos;
using Core.Model;
using Core.Repositories;
using Core.Results;
using Core.Services;
using Core.UnitOfWorks;
using FluentValidation;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class QuestionService: Service<Question,QuestionDto>  , IQuestionService

    {
        private readonly IValidator<QuestionDto> _questionValidator;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IGenericRepository<Question> repository, IUnitOfWork unitOfWork, IValidator<QuestionDto> questionValidator, IMapper mapper, IQuestionRepository questionRepository) : base(repository, unitOfWork)
        {
            _questionValidator = questionValidator;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public override async Task<IDataResult<QuestionDto>> AddAsync(QuestionDto entity)
        {
            var validationResults = await _questionValidator.ValidateAsync(entity);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<QuestionDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }
            return await base.AddAsync(entity);
        }

        public override async Task<IResult> UpdateAsync(QuestionDto entity)
        {
            var validationResults = await _questionValidator.ValidateAsync(entity);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<QuestionDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }
            return await base.UpdateAsync(entity);
        }

        public async Task<DataResult<List<QuestionWithSurveyDto>>> GetQuestionsWithSurvey()
        {
            var questions = await _questionRepository.GetQuestionsWithSurvey();
            var questionsDto = _mapper.Map<List<QuestionWithSurveyDto>>(questions);
            return new SuccessDataResult<List<QuestionWithSurveyDto>>(questionsDto);
        }
    }
}
