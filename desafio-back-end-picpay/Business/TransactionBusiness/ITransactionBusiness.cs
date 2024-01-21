using desafio_back_end_picpay.Data.DTOs;

namespace desafio_back_end_picpay.Business.TransactionBusiness;

public interface ITransactionBusiness
{
    TransactionDTO Payment(TransactionDTO paymentInfo);
}
