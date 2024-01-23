using desafio_back_end_picpay.Business;
using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Hypermedia.Filters;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("findAll")]
    [ProducesResponseType(typeof(List<UserDTO>), 200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult FindAll()
    {
        var users = _business.FindAll();
        return Ok(users);
    }

    [HttpGet("findById/{id}")]
    [ProducesResponseType(typeof(UserDTO), 200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult FindById([FromRoute]int id)
    {
        var person = _business.GetById(id);
        if (person is null) 
            return NotFound();
        return Ok(person);
    }

    [HttpGet("findByName")]
    [ProducesResponseType(typeof(UserDTO), 200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult FindByName([FromQuery]string user)
    {
        var person = _business.FindUserByName(user);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost("createUser")]
    [ProducesResponseType(typeof(UserDTO), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Post([FromBody] UserDTO user)
    {
        if (user == null) return BadRequest();
        return Ok(_business.Create(user));
    }

    [HttpPut("updateUser")]
    [ProducesResponseType(typeof(UserDTO), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Put([FromBody] UserDTO user)
    {
        if (user == null) return BadRequest();
        return Ok(_business.Update(user));
    }

    [HttpDelete("deleteUser/{name}")]
    [ProducesResponseType(typeof(UserDTO), 200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Delete(string name)
    {
        var user = _business.FindUserByName(name);
        _business.Delete(user.Id);
        return NoContent();
    }
}
