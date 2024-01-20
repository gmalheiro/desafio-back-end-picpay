using desafio_back_end_picpay.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace desafio_back_end_picpay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserBusiness _business;

    public UserController(IUserBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        var users = _business.FindAll();
        return Ok(users);
    }
}
