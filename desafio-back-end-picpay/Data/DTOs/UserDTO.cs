using System.ComponentModel.DataAnnotations;

namespace desafio_back_end_picpay.Data.DTOs;

public record UserDTO
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
    [Length(14, 18)]
    string DocumentNumber,
    [Required]
    bool IsPessoaFisica
);
