namespace desafio_back_end_picpay.Data.DTOs;

public record TransactionStatus
    (
        string sent,
        string operation,
        string sender,
        string receiver,
        string message
    );
