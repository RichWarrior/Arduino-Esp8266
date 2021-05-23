using Core.Entities;
using Core.Interfaces;
using Core.Utilities;
using Core.Utilities.Result;
using NETCore.Encrypt;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;

namespace Service.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IDataResult<User> FindByEmail(string email)
        {
            var user = connection.ExecuteCommand<User>("SELECT * FROM user WHERE Email = @email AND Status = 1", email)?.FirstOrDefault();
            if (user == null)
                return new ErrorDataResult<User>(null);
            return new SuccessDataResult<User>(user, Messages.User.AlreadyExists);
        }       

        public IDataResult<int> Register(User user)
        {
            user.Password = EncryptProvider.Md5(user.Password);
            var userId = connection.Insert(user);
            if (userId > 0)
                return new SuccessDataResult<int>(userId);
            return new ErrorDataResult<int>(0,Messages.User.NotRegistered);
        }

        public IResult LogIn(User user, string password)
        {
            if (user.Password != EncryptProvider.Md5(password))
                return new ErrorResult(Messages.User.NotLogIn);

            var token = JWTManager.GenerateToken(user);

            try
            {
                var db = cache.GetDatabase(0);
                db.StringSet($"{token}_user", JsonConvert.SerializeObject(user), TimeSpan.FromDays(1));
            }
            catch (System.Exception)
            {
                return new ErrorResult(Messages.User.NotLogIn);
            }
            return new SuccessResult(token);
        }

        public IDataResult<User> CheckToken(string token)
        {
            token += "_user";
            var db = cache.GetDatabase(0);
            if (!db.KeyExists(token))
                return new ErrorDataResult<User>(null, Messages.UnAuthorized);
            var userJson = db.StringGet(token);
            try
            {
                return new SuccessDataResult<User>(JsonConvert.DeserializeObject<User>(userJson));
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>(null, Messages.UnAuthorized);
            }
        }

        public IDataResult<User> FindById(int id)
        {
            string sql = "SELECT * FROM user WHERE Id = @id AND Status = 1";
            var user = connection.ExecuteCommand<User>(sql, id)?.FirstOrDefault();
            if (user == null)
                return new ErrorDataResult<User>(null, Messages.User.NotFound);
            return new SuccessDataResult<User>(user);
        }
    }
}
