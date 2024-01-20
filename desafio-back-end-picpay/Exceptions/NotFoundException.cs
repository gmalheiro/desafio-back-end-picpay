namespace desafio_back_end_picpay.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) : base(message){}
}
