namespace desafio_back_end_picpay.Data.DTOs;

public record TransactionDTO 
(
    double Value,
    int sender,
    int receiver
);
