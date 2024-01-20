using System.ComponentModel.DataAnnotations;

namespace desafio_back_end_picpay.Data.DTOs;

public record ShopKeeperDTO 
(
    [Required]
    string FullName,
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    string Password,
    [Required]
    double Balance,
    [Required]
    [StringLength(18, MinimumLength = 14)]
    string CNPJ
);
