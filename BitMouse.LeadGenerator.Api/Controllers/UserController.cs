using BitMouse.LeadGenerator.Contract.Users;
using Microsoft.AspNetCore.Mvc;

namespace BitMouse.LeadGenerator.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task SaveUserAsync(UserRequestDto request)
    {
        await _userService.SaveUserAsync(request);
    }
}
