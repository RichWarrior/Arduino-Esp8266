using Core.Interfaces;
using System.Data;

namespace Service.Repositories
{
    public class DeviceDetailRepository : BaseRepository,IDeviceDetailRepository
    {
        public DeviceDetailRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
