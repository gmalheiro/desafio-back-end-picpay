using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using desafio_back_end_picpay.Models.Generic;

namespace desafio_back_end_picpay.Models;

[Table("shopkeeper")]
public class ShopKeeper : BaseEntity
{
    [Required]
    [StringLength(18, MinimumLength = 14)]
    public string? CNPJ { get; set; }
}
