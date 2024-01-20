using desafio_back_end_picpay.Data.Context;
using desafio_back_end_picpay.Models;
using desafio_back_end_picpay.Repository.Generic;

namespace desafio_back_end_picpay.Repository.UserRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }
}
