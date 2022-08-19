using Core.Dtos;
using Core.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyManagementAPI.Responses;

namespace SurveyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        protected ActionResult Ok(Core.Results.IResult result)
        {
            var response = new Response(result);
            if (!result.HasError) return base.Ok(response);
            return BadRequest(response);
        }

        protected ActionResult Ok<T>(IDataResult<T> result)
        {
            var response = new DataResponse<T>(result);
            if (!result.HasError) return base.Ok(response);
            return BadRequest(response);
        }

        protected ActionResult Ok<T>(IListResult<T> result)
        {
            var response = new ListResponse<T>(result);
            if (!result.HasError) return base.Ok(response);
            return BadRequest(response);
        }
    }
}
