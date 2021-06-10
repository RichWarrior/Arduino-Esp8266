using Core.Entities;
using Core.Interfaces;
using Core.Utilities;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Service.Repositories
{
    public class DeviceRepository : BaseRepository,IDeviceRepository
    {
        public DeviceRepository(IDbTransaction transaction) : base(transaction)
        {
        }        

        public IDataResult<Device> FindById(int id)
        {
            string sql = @"SELECT 
                d.*,
                dt.Name AS DeviceTypeName               
              FROM device d
            INNER JOIN devicetype dt ON dt.Id = d.DeviceTypeId
            WHERE d.Id = @id AND d.Status = 1";
            var result = connection.ExecuteCommand<Device>(sql, id)?.FirstOrDefault();
            return new SuccessDataResult<Device>(result);
        }

        public IDataResult<List<Device>> GetDevices(int userId)
        {
            string sql = @"SELECT 
                d.*,
                dt.Name AS DeviceTypeName
              FROM device d
            INNER JOIN devicetype dt ON dt.Id = d.DeviceTypeId
            WHERE d.UserId = @userId AND d.Status = 1";
            var result = connection.ExecuteCommand<Device>(sql, userId).ToList();
            return new SuccessDataResult<List<Device>>(result);
        }

        public IResult Insert(Device device)
        {
            device.Id = connection.Insert(device);
            if (device.Id > 0)
                return new SuccessResult();
            return new ErrorResult(Messages.Device.NotInserted);
        }

        public IResult Delete(Device device)
        {
            var result = connection.Delete(device);

            return result ? new SuccessResult() : new ErrorResult(Messages.Device.NotDeleted);
        }

        public IResult Update(Device device)
        {
            var result = connection.Update(device);
            return result ? new SuccessResult() : new ErrorResult(Messages.Device.NotUpdated);
        }
    }
}
