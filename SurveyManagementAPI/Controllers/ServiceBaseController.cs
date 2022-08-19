using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace SurveyManagementAPI.Controllers
{
    public class ServiceBaseController<T, TDto>  : CustomBaseController
        where T : class where TDto : class
    {
        IService<T, TDto> _service;


        public ServiceBaseController(IService<T, TDto> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TDto tdto)
        {
            return Ok(await _service.AddAsync(tdto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TDto tdto)
        {
            return Ok(await _service.UpdateAsync(tdto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return Ok(await _service.RemoveAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

    }
}
   