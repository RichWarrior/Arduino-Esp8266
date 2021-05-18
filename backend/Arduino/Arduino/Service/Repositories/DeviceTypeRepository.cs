using Core.Interfaces;
using System.Data;

namespace Service.Repositories
{
    public class DeviceTypeRepository : BaseRepository, IDeviceTypeRepository
    {
        public DeviceTypeRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
