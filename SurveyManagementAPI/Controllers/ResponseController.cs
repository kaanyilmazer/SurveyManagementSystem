using AutoMapper;
using Core.Dtos;
using Core.Model;
using Core.Results;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Redis;
using SurveyManagementAPI.Filters;

namespace SurveyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ServiceBaseController<Response, ResponsesDto>
    {
        private readonly IResponseService _service;

        public ResponseController(IResponseService service) : base(service)
        {
            _service = service;
        }

        [Cached(600)]
        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}

