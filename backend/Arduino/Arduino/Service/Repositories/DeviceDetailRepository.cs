using Core.Entities;
using Core.Interfaces;
using Core.Utilities;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Service.Repositories
{
    public class DeviceDetailRepository : BaseRepository,IDeviceDetailRepository
    {
        public DeviceDetailRepository(IDbTransaction transaction) : base(transaction)
        {
        }


        public IResult Insert(DeviceDetail deviceDetail)
        {
            deviceDetail.Id = connection.Insert(deviceDetail);
            return deviceDetail.Id > 0 ? new SuccessResult() : new ErrorResult(Messages.DeviceDetail.NotInserted);
        }
        
        public IDataResult<List<DeviceDetail>> GetDeviceDetails(int deviceId)
        {
            string sql = @"SELECT dd.*,
                p.PinName AS Pin,
                s.Name AS SensorName
            FROM devicedetail dd
            INNER JOIN pin p ON p.Id = dd.PinId
            INNER JOIN sensor s ON s.Id = dd.SensorId
            WHERE  dd.DeviceId = @deviceId AND dd.Status = 1";
            var result = connection.ExecuteCommand<DeviceDetail>(sql, deviceId).ToList();
            return new SuccessDataResult<List<DeviceDetail>>(result);
        }

        public IDataResult<DeviceDetail> GetDeviceDetail(int id)
        {
            string sql = @"SELECT dd.*,
                p.PinName AS Pin,
                s.Name AS SensorName
            FROM devicedetail dd
            INNER JOIN pin p ON p.Id = dd.PinId
            INNER JOIN sensor s ON s.Id = dd.SensorId
            WHERE  dd.Id = @id AND dd.Status = 1";
            var result = connection.ExecuteCommand<DeviceDetail>(sql, id)?.FirstOrDefault();
            return result != null ? new SuccessDataResult<DeviceDetail>(result) : new ErrorDataResult<DeviceDetail>(null, Messages.DeviceDetail.NotFound);
        }

        public IResult DeleteDeviceDetail(DeviceDetail deviceDetail)
        {
            bool isDeleted = connection.Delete(deviceDetail);
            return isDeleted ? new SuccessResult() : new ErrorResult(Messages.DeviceDetail.NotDeleted);
        }
    }
}
