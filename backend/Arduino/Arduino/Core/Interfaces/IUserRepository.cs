using Core.Entities;
using Core.Utilities.Result;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        IDataResult<User> FindByEmail(string email);
        IDataResult<int> Register(User user);
        IResult LogIn(User user, string password);
        IDataResult<User> CheckToken(string token);
        IDataResult<User> FindById(int id);
    }
}
