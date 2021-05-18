using Core.Interfaces;
using System.Data;

namespace Service.Repositories
{
    public class UserRepository : BaseRepository,IUserRepository
    {
        public UserRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
