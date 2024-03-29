﻿using desafio_back_end_picpay.Business;
using desafio_back_end_picpay.Business.TransactionBusiness;
using desafio_back_end_picpay.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace desafio_back_end_picpay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionBusiness _transactionBusiness;

    public TransactionController(ITransactionBusiness transactionBusiness)
    {
        _transactionBusiness = transactionBusiness;
    }

    [HttpPost("transaction")]
    [ProducesResponseType(typeof(TransactionStatus), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Post([FromBody] TransactionDTO paymentInfo)
    {
        var response = await _transactionBusiness.Payment(paymentInfo);
        return Ok(response);
    }

}
