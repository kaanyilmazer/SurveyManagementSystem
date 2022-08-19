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
    public class QuestionController : ServiceBaseController<Question, QuestionDto>
    {
        
        private readonly IMapper _mapper;
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetQuestionsWithSurvey()
        {
            return Ok(await _service.GetQuestionsWithSurvey());
        }

    }
}