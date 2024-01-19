namespace desafio_back_end_picpay.Data.DTOs;

public record Transaction 
(
    double Value,
    int sender,
    int receiver
);
