using desafio_back_end_picpay.Data.Context;
using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Models;
using desafio_back_end_picpay.Repository.Generic;
using System.Data;

namespace desafio_back_end_picpay.Repository.UserRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {

    }

    public User FindUserByName(string name)
    {
        var user = _context.Users.FirstOrDefault(u => u.FullName == name );
        
        if (user is null)
            return null!;
        return user;
    }

    public void UpdateBalance(int id, double balance)
    {
        var userToBeUpdated = _context.Users.FirstOrDefault(u => u.Id == id);
        
        userToBeUpdated!.Balance = balance;

        _context.SaveChanges();
    }
}
