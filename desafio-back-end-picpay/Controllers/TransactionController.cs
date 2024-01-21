using desafio_back_end_picpay.Business;
using desafio_back_end_picpay.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace desafio_back_end_picpay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    [HttpPost("payment")]
    [ProducesResponseType(typeof(TransactionDTO), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Post([FromBody] TransactionDTO paymentInfo)
    {
        return Ok(paymentInfo);
    }

}
