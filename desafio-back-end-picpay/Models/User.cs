using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using desafio_back_end_picpay.Models.Generic;

namespace desafio_back_end_picpay.Models;

[Table("users")]
public class User : BaseEntity
{
    [Required]
    [StringLength(14,MinimumLength = 11)]
    [Column("cpf")]
    public string? Cpf { get; set; }
}
