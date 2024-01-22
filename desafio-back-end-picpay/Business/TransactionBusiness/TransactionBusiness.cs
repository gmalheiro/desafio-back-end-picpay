using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Repository.UserRepository;
using desafio_back_end_picpay.Services;

namespace desafio_back_end_picpay.Business.TransactionBusiness;

public class TransactionBusiness : ITransactionBusiness
{
    private readonly IUserRepository _userRepository;

    public TransactionBusiness(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<TransactionStatus> Payment(TransactionDTO paymentInfo)
    {
        try
        {
            var authorizationService = await AuthorizationService.CallAuthorizationService();

            if (authorizationService)
            {
                var sender = _userRepository.FindById(paymentInfo.sender);
                var receiver = _userRepository.FindById(paymentInfo.receiver);

                if (!sender.IsPessoaFisica)
                    return new TransactionStatus("not sent",
                                                 "unauthorized",
                                                     "",
                                                 receiver?.FullName ?? "",
                                                 "The operation was not possible due to user being a shopkeeper");

                if (sender.Balance < paymentInfo.Value)
                    return new TransactionStatus("not sent",
                                                 "unauthorized",
                                                 sender?.FullName ?? "",
                                                 receiver?.FullName ?? "",
                                                 "The operation was not possible due to user not having enough balance");

                sender.Balance = sender.Balance - paymentInfo.Value;
                receiver.Balance = receiver.Balance + paymentInfo.Value;

                _userRepository.UpdateBalance(sender.Id, sender.Balance);
                _userRepository.UpdateBalance(receiver.Id, receiver.Balance);

                var notificationService = await NotificationService.CallNotificationService();

                if (notificationService)
                {
                    return new TransactionStatus("sent",
                                                  "authorized",
                                                  sender?.FullName ?? "",
                                                  receiver?.FullName ?? "",
                                                  $"The operation was successful {sender?.FullName} sent {paymentInfo.Value} to {receiver?.FullName}");
                }
                else
                {
                    return new TransactionStatus("not sent",
                                                  "authorized",
                                                  sender?.FullName ?? "",
                                                  receiver?.FullName ?? "",
                                                  $"The operation was successful {sender?.FullName} sent {paymentInfo.Value} to {receiver?.FullName}");
                }
            }


            return new TransactionStatus(    "not sent",
                                             "unauthorized",
                                              "",
                                              "",
                                             $"The operation unsuccessful");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception("An error occured during process please come back later");
        }
    }
}
