using Core.Entities;
using Core.Utilities.Result;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IDeviceDetailRepository
    {
        IResult Insert(DeviceDetail deviceDetail);
        IDataResult<List<DeviceDetail>> GetDeviceDetails(int deviceId);
        IDataResult<DeviceDetail> GetDeviceDetail(int id);
        IResult DeleteDeviceDetail(DeviceDetail deviceDetail);
    }
}
