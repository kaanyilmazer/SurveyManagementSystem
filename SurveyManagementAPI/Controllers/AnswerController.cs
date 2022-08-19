using AutoMapper;
using Core.Dtos;
using Core.Model;
using Core.Results;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SurveyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ServiceBaseController<Answer, AnswerDto>
    {
      
        private readonly IMapper _mapper;
        private readonly IAnswerService _service;

        public AnswerController(IAnswerService service ,IMapper mapper) : base(service)
        {
            
            _mapper = mapper;
            _service = service;
        }

        //[Authorize(Roles="Admin")]
      
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAnswerWithQuestion()
        {
            return Ok(await _service.GetAnswerWithQuestion());
        }
    }
}
