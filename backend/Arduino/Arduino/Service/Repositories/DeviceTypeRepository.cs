using Core.Entities;
using Core.Interfaces;
using Core.Utilities;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Service.Repositories
{
    public class DeviceTypeRepository : BaseRepository, IDeviceTypeRepository
    {
        public DeviceTypeRepository(IDbTransaction transaction) : base(transaction)
        {
        }


        public IDataResult<List<DeviceType>> List()
        {
            string sql = "SELECT * FROM devicetype WHERE Status = 1";
            var result = connection.ExecuteCommand<DeviceType>(sql).ToList();
            return new SuccessDataResult<List<DeviceType>>(result);
        }
        public IDataResult<DeviceType> FindById(int id)
        {
            string sql = "SELECT * FROM devicetype WHERE Id = @id AND Status = 1";
            var result = connection.ExecuteCommand<DeviceType>(sql, id)?.FirstOrDefault();
            if (result == null)
                return new ErrorDataResult<DeviceType>(null, Messages.DeviceType.NotFound);
            return new SuccessDataResult<DeviceType>(result);
        }
    }
}
