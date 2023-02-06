using BitMouse.LeadGenerator.Contract.Users;
using Microsoft.AspNetCore.Mvc;

namespace BitMouse.LeadGenerator.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : Controller
{
    [HttpPost]
    public async Task<ActionResult> SaveUserAsync(UserRequestDto input)
    {
        throw new NotImplementedException();
    }
}
