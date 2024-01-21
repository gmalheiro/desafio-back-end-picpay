using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Exceptions;
using desafio_back_end_picpay.Models;
using desafio_back_end_picpay.Repository.UserRepository;
using desafio_back_end_picpay.Utils;
using Serilog;

namespace desafio_back_end_picpay.Business;

public class UserBusiness : IUserBusiness
{
    private readonly IUserRepository _repository;

    public UserBusiness(IUserRepository repository)
    {
        _repository = repository;
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
                DocumentNumber = UtilsClass.RemoveSpecialCharacters(user.DocumentNumber),
                IsPessoaFisica = user.IsPessoaFisica
            };

            var userInDb = _repository.FindUserByName(userToBeCreated.FullName);

            if (userInDb != null || userInDb?.Email == user.Email || userInDb?.DocumentNumber == user.DocumentNumber)
                throw new NotPossibleOperation("It's not possible to create user, user already exists in database! Try using a different email and document number");

            if (user.IsPessoaFisica && UtilsClass.DetectSpecialCharacters(user.DocumentNumber))
                userToBeCreated!.DocumentNumber = UtilsClass.RemoveSpecialCharacters(user.DocumentNumber);
            else
                userToBeCreated!.DocumentNumber = user.DocumentNumber;


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


        string userDocument;

        if (userInDb.IsPessoaFisica)
            userDocument = UtilsClass.FormatCPF(userInDb?.DocumentNumber ?? "");
        else
            userDocument = UtilsClass.FormatCNPJ(userInDb?.DocumentNumber ?? "");

        var user = new UserDTO
            (
                userInDb?.FullName ?? "",
                userInDb?.Email ?? "",
                userInDb?.Password ?? "",
                userInDb?.Balance ?? 0,
                userDocument,
                userInDb?.IsPessoaFisica ?? true
            );

        return user;
    }

    public List<UserDTO> FindAll()
    {
        var users = new List<UserDTO>();

        var usersInDB = _repository.FindAll();

        foreach (var userInDB in usersInDB)
        {

            string userDocument;

            if (userInDB.IsPessoaFisica)
                userDocument = UtilsClass.FormatCPF(userInDB?.DocumentNumber ?? "");
            else
                userDocument = UtilsClass.FormatCNPJ(userInDB?.DocumentNumber ?? "");

            var user = new UserDTO
            (
                userInDB?.FullName ?? "",
                userInDB?.Email ?? "",
                userInDB?.Password ?? "",
                userInDB?.Balance ?? 0,
                userDocument,
                userInDB?.IsPessoaFisica ?? false
            );

            users.Add(user);
        }

        return users;
    }

    public User FindUserByName(string name)
    {
        var userInDb = _repository.FindUserByName(name);

        if (userInDb is null)
            throw new NotFoundException("User was not found");

        return userInDb;

    }

    public UserDTO GetById(int id)
    {
        try
        {
            var userInDb = _repository.FindById(id);

            if (userInDb != null)
            {

                string userDocument;

                if (userInDb.IsPessoaFisica)
                    userDocument = UtilsClass.FormatCPF(userInDb?.DocumentNumber ?? "");
                else
                    userDocument = UtilsClass.FormatCNPJ(userInDb?.DocumentNumber ?? "");

                var user = new UserDTO
                (
                    userInDb?.FullName ?? "",
                    userInDb?.Email ?? "",
                    userInDb?.Password ?? "",
                    userInDb?.Balance ?? 0,
                    userDocument,
                    userInDb?.IsPessoaFisica ?? true
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
                throw new NotFoundException($"User with name {user.FullName} not found");

            string userDocument;

            if (userEntity.IsPessoaFisica)
                userDocument = UtilsClass.FormatCPF(userEntity?.DocumentNumber ?? "");
            else
                userDocument = UtilsClass.FormatCNPJ(userEntity?.DocumentNumber ?? "");

            userEntity!.FullName = user.FullName;
            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            userEntity.Balance = user.Balance;
            userEntity.DocumentNumber = userDocument;

            _repository.Update(userEntity);

            return user;
        }
        catch (Exception e)
        {
            Log.Error($"An error occurred while updating the user: {e}");
            throw new Exception("An error occurred while updating the user.");
        }
    }

}
