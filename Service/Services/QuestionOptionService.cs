using AutoMapper;
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
    //private readonly IMapper _mapper;

    public class QuestionOptionService : Service<QuestionOption, QuestionOptionsDto>, IQuestionOptionService
    {
        public QuestionOptionService(IGenericRepository<QuestionOption> repository, IUnitOfWork unitOfWork,IMapper mapper) : base(repository, unitOfWork,mapper)
        {
        }
    }
}
