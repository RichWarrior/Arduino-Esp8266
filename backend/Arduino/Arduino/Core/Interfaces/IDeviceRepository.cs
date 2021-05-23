using Core.Entities;
using Core.Utilities.Result;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IDeviceRepository
    {
        IDataResult<List<Device>> GetDevices(int userId);
        IResult Insert(Device device);
        IDataResult<Device> FindById(int id);
        IResult Delete(Device device);
        IResult Update(Device device);
    }
}
