namespace desafio_back_end_picpay.Models.Generic.Interfaces;

public interface IBaseEntity
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
