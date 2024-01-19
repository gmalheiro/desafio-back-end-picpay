using System.ComponentModel.DataAnnotations;
using desafio_back_end_picpay.Models.Generic;

namespace desafio_back_end_picpay.Models;

public class Shopkeeper : Client
{
    [Required]
    [StringLength(18, MinimumLength = 14)]
    public string? CNPJ { get; set; }
}
