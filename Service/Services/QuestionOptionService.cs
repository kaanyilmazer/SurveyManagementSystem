using Core.Dtos;
using Core.Model;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class QuestionOptionService : Service<QuestionOption, QuestionOptionsDto>, IQuestionOptionService
    {
        public QuestionOptionService(IGenericRepository<QuestionOption> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
