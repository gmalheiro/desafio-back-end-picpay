﻿using desafio_back_end_picpay.Data.Context;
using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Models;
using desafio_back_end_picpay.Repository.UserRepository;
using desafio_back_end_picpay.Utils;
using Microsoft.EntityFrameworkCore;
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

        //var item = new List<User>();
        //try
        //{

        //    item = _dbContext.Users;

        //    return item == null ? new List<T>() : item;
        //}
        //catch (Exception e)
        //{

        //    Console.WriteLine(e.Message);
        //    return item == null ? new List<T>() : item;
        //}

        var users = new List<UserDTO>();

        var usersInDB = _dbContext.Users.ToList(); ;

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

    public UserDTO GetById(int id)
    {
        var userInDb = _repository.FindById(id);

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

    public UserDTO Update(UserDTO user)
    {
        var userToBeSaved = new User()
        {
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            Balance = user.Balance,
            Cpf = UtilsClass.RemoveSpecialCharacters(user.CPF)
        };

        _repository.Update(userToBeSaved);

        return user;
    }
}