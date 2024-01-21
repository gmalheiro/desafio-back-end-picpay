namespace desafio_back_end_picpay.Exceptions;

public class NotPossibleOperation : ApplicationException
{
    public NotPossibleOperation(string message) : base(message){}
}
