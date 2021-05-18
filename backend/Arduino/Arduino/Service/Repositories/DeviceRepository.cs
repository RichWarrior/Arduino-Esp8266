using Core.Interfaces;
using System.Data;

namespace Service.Repositories
{
    public class DeviceRepository : BaseRepository,IDeviceRepository
    {
        public DeviceRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
