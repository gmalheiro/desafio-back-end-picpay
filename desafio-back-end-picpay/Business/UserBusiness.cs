using desafio_back_end_picpay.Data.Context;
using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Exceptions;
using desafio_back_end_picpay.Models;
using desafio_back_end_picpay.Repository.UserRepository;
using desafio_back_end_picpay.Utils;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Data;

namespace desafio_back_end_picpay.Business;

public class UserBusiness : IUserBusiness
{
    private readonly IUserRepository _repository;
    private readonly DatabaseContext _dbContext;

    public UserBusiness(IUserRepository repository, DatabaseContext dbContext)
    {
        _repository = repository;
        _dbContext = dbContext;
    }

    public UserDTO Create(UserDTO user)
    {
        try
        {
            var userToBeCreated = new User()
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                Balance = user.Balance,
                Cpf = UtilsClass.RemoveSpecialCharacters(user.CPF),
            };

            _repository.Create(userToBeCreated);

            return user;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public UserDTO Delete(int id)
    {
        var userInDb = _repository.FindById(id);

        _repository.Delete(id);

        var user = new UserDTO
            (
                userInDb?.FullName ?? "",
                userInDb?.Email ?? "",
                userInDb?.Password ?? "",
                userInDb?.Balance ?? 0,
                UtilsClass.FormatCPF(userInDb?.Cpf ?? "")
            );

        return user;
    }

    public List<UserDTO> FindAll()
    {
        var users = new List<UserDTO>();

        var usersInDB = _repository.FindAll(); 

        foreach (var userInDB in usersInDB)
        {
            var user = new UserDTO
            (
                userInDB?.FullName ?? "",
                userInDB?.Email ?? "",
                userInDB?.Password ?? "",
                userInDB?.Balance ?? 0,
                UtilsClass.FormatCPF(userInDB?.Cpf ?? "")
            );

            users.Add(user);
        }

        return users;
    }

    public User FindUserByName(string name)
    {
        var userInDb = _repository.FindUserByName(name);

        return userInDb;

    }

    public UserDTO GetById(int id)
    {
        try
        {
            var userInDb = _repository.FindById(id);

            if (userInDb != null)
            {
                var user = new UserDTO
                (
                    userInDb?.FullName ?? "",
                    userInDb?.Email ?? "",
                    userInDb?.Password ?? "",
                    userInDb?.Balance ?? 0,
                    UtilsClass.FormatCPF(userInDb?.Cpf ?? "")
                );

                return user;
            }
            else
            {
                throw new NotFoundException($"User with ID {id} not found");
            }
        }
        catch (Exception e)
        {
            throw new NotFoundException($"An error occurred while fetching the user: {e.Message}");
        }
    }


    public UserDTO Update(UserDTO user)
    {
        try
        {
            var userEntity = _repository.FindUserByName(user.FullName);

            if (userEntity == null)
            {
                throw new NotFoundException($"User with name {user.FullName} not found");
            }

            userEntity.FullName = user.FullName;
            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            userEntity.Balance = user.Balance;
            userEntity.Cpf = UtilsClass.RemoveSpecialCharacters(user.CPF);

            _repository.Update(userEntity);

            return user;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception e)
        {
            Log.Error($"An error occurred while updating the user: {e}");
            throw new NotFoundException("An error occurred while updating the user.");
        }
    }

}
