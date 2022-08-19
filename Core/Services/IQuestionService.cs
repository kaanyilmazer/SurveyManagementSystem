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
    public interface IQuestionService : IService<Question,QuestionDto>
    {
        Task<DataResult<List<QuestionWithSurveyDto>>> GetQuestionsWithSurvey();
    }
}
