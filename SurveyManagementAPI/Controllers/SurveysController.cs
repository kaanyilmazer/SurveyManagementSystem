using AutoMapper;
using Core.Dtos;
using Core.Model;
using Core.Results;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Redis;
using Service.Services;
using SurveyManagementAPI.Filters;

namespace SurveyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ServiceBaseController <Survey,SurveyDto>
    {
        private readonly ISurveyService _service;

        public SurveysController(ISurveyService service) : base(service)
        {
            _service = service;
        }


        [HttpGet("[action]/{surveyId}")]
        public async Task<IActionResult> GetSurveyByIdQuestionAsync(int surveyId)
        {
            return Ok(await _service.GetSurveyByIdQuestionAsync(surveyId));
        }

        [Authorize(Roles = "Admin")]
        [Cached(600)]
        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
   