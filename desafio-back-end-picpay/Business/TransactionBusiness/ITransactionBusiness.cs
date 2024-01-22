using desafio_back_end_picpay.Data.DTOs;

namespace desafio_back_end_picpay.Business.TransactionBusiness;

public interface ITransactionBusiness
{
    Task<TransactionStatus> Payment (TransactionDTO paymentInfo);
}
