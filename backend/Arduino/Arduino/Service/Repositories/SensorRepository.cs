using Core.Interfaces;
using System.Data;

namespace Service.Repositories
{
    public class SensorRepository : BaseRepository,ISensorRepository
    {
        public SensorRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
