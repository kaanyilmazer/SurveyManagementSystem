using AutoMapper;
using Core.Dtos;
using Core.Model;
using Core.Results;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyManagementAPI.Filters;

namespace SurveyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionOptionController : ServiceBaseController<QuestionOption, QuestionOptionsDto>
    {
        private readonly IQuestionOptionService  _service;
        private readonly IMapper _mapper;

        public QuestionOptionController(IQuestionOptionService service) : base(service)
        {
        }

    }
}