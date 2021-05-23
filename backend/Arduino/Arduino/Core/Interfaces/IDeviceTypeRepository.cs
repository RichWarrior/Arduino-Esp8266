using Core.Entities;
using Core.Utilities.Result;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IDeviceTypeRepository 
    {
        IDataResult<List<DeviceType>> List();
        IDataResult<DeviceType> FindById(int id);
    }
}
