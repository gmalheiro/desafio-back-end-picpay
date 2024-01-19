using desafio_back_end_picpay.Models.Generic.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio_back_end_picpay.Models.Generic;

public class Client : IClient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("full_name")]
    [Required]
    [StringLength(100)]
    public string? FullName { get; set; }
    [Column("email")]
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Column("password")]
    [Required]
    public string? Password { get; set; }
    [Column("balance")]
    public double Balance { get; set; }
}
