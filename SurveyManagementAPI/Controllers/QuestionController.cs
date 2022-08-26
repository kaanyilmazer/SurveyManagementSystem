using AutoMapper;
using Core.Dtos;
using Core.Model;
using Core.Results;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Redis;
using SurveyManagementAPI.Filters;

namespace SurveyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ServiceBaseController<Question, QuestionDto>
    { 
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service) : base(service)
        {
            _service = service;
        }


        [Authorize]
        [Cached(600)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetQuestionsWithSurvey()
        {
            return Ok(await _service.GetQuestionsWithSurvey());
        }

    }
}