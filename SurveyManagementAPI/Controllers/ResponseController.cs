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
    public class ResponseController : ServiceBaseController<Response, ResponsesDto>
    {
        private readonly IResponseService _service;

        public ResponseController(IResponseService service) : base(service)
        {
            service = _service;
        }

    }
}

