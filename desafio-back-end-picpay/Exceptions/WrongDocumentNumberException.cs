namespace desafio_back_end_picpay.Exceptions;

public class WrongDocumentNumberException : ApplicationException
{
    public WrongDocumentNumberException(string message) : base(message){}
}
