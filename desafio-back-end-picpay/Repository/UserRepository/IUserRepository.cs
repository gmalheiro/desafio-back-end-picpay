﻿using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Models;
using desafio_back_end_picpay.Repository.Generic;

namespace desafio_back_end_picpay.Repository.UserRepository;

public interface IUserRepository : IRepository<User>
{
    User FindUserByName(string name);
    void UpdateBalance(int id, double balance);
}
