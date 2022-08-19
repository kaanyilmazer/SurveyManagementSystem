
using AutoMapper;
using Core.Dtos;
using Core.Model;
using Core.Repositories;
using Core.Results;
using Core.Services;
using Core.UnitOfWorks;
using FluentValidation;
using Repository.Repositories;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SurveyService : Service<Survey, SurveyDto> , ISurveyService

    {
        private readonly IValidator<SurveyDto> _surveyValidator;
        private readonly ISurveyRepository _repo;
        private readonly IMapper _mapper;

        public SurveyService(IGenericRepository<Survey> repository, IUnitOfWork unitOfWork, IValidator<SurveyDto> surveyValidator, ISurveyRepository repo, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _surveyValidator = surveyValidator;
            _repo = repo;
            _mapper = mapper;
        }

        public override async Task<IDataResult<SurveyDto>> AddAsync(SurveyDto entity)
        {
            var validationResults = await _surveyValidator.ValidateAsync(entity);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<SurveyDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }
            return await base.AddAsync(entity);
        }

        public override async Task<IResult> UpdateAsync(SurveyDto entity)
        {
            var validationResults = await _surveyValidator.ValidateAsync(entity);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<SurveyDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }

            return  await base.UpdateAsync(entity);
        }

        public async Task<DataResult<SurveyAndQuestionsDto>> GetSurveyByIdQuestionAsync(int surveyId)
        {
            var survey = await _repo.GetSurveyByIdQuestionAsync(surveyId);
            var surveyDto = _mapper.Map<SurveyAndQuestionsDto>(survey);
            return new SuccessDataResult<SurveyAndQuestionsDto>(surveyDto);
        }
    }
}
