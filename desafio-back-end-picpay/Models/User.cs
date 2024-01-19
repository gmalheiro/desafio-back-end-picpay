using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using desafio_back_end_picpay.Models.Generic;

namespace desafio_back_end_picpay.Models;

public class User : Client
{
    [Required]
    [StringLength(14,MinimumLength = 11)]
    [Column("cpf")]
    public string? Cpf { get; set; }
}
