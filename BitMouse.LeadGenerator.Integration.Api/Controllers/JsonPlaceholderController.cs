using BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder;
using BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder.Users;
using Microsoft.AspNetCore.Mvc;

namespace BitMouse.LeadGenerator.Integration.Api.Controllers
{
    [Route("api/integrations/json-placeholder")]
    [ApiController]
    public class JsonPlaceholderController : Controller
    {
        private readonly IJsonPlaceholderService _jsonPlaceholderService;

        public JsonPlaceholderController(IJsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto?>> GetUserAsync([FromQuery] GetUsersRequest request)
        {
            var user = (await _jsonPlaceholderService.GetUsersAsync(request))
                .Users?
                .FirstOrDefault();

            return user;
        }
    }
}
