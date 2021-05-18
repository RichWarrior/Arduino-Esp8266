using Core.Interfaces;
using System.Data;

namespace Service.Repositories
{
    public class PinRepository : BaseRepository, IPinRepository
    {
        public PinRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
