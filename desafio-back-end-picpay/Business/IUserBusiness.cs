using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Models;

namespace desafio_back_end_picpay.Business;

public interface IUserBusiness
{
    List<UserDTO> FindAll();
    UserDTO GetById(int id);   
    UserDTO Create(UserDTO user);
    UserDTO Update(UserDTO user); 
    UserDTO Delete(int id);
}
