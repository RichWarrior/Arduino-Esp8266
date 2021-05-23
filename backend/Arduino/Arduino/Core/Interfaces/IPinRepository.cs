using Core.Entities;
using Core.Utilities.Result;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IPinRepository
    {
        IDataResult<List<Pin>> GetAvailablePins(int deviceId, int deviceTypeId);
    }
}
