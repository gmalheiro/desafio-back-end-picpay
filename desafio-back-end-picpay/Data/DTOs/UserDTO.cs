using desafio_back_end_picpay.Hypermedia;
using desafio_back_end_picpay.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations;

namespace desafio_back_end_picpay.Data.DTOs;

public class UserDTO : ISupportsHyperMedia
{
    [Required]
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public double Balance { get; set; }

    [Required]
    [Length(14, 18)]
    public string DocumentNumber { get; set; }

    [Required]
    public bool IsPessoaFisica { get; set; }

    public int Id { get; set; }

    public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    public UserDTO(string fullName,string email,string password, double balance, string documentNumber, bool isPessoaFisica)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        Balance = balance;
        DocumentNumber = documentNumber;
        IsPessoaFisica = isPessoaFisica;
    }

    public UserDTO(string fullName, string email, string password, double balance, string documentNumber, bool isPessoaFisica,int id)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        Balance = balance;
        DocumentNumber = documentNumber;
        IsPessoaFisica = isPessoaFisica;
        Id = id;
    }

}