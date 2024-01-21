using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using desafio_back_end_picpay.Models.Generic;

namespace desafio_back_end_picpay.Models;

[Table("users")]
public class User : BaseEntity
{
    [Required]
    [Length(14, 18)]
    [Column("document_number")]
    public string? DocumentNumber { get; set; }
    [Column("is_pessoa_fisica")]
    public bool IsPessoaFisica { get; set;}
}
