using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISurveyRepository:IGenericRepository<Survey>
    {
        Task<Survey> GetSurveyByIdQuestionAsync(int surveyId);
    }
}
