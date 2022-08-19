using Core.Dtos;
using Core.Model;
using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ISurveyService : IService<Survey,SurveyDto>
    {
        public Task<DataResult<SurveyAndQuestionsDto>> GetSurveyByIdQuestionAsync(int surveyId);
    }
}
