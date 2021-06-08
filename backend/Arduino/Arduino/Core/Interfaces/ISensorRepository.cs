using Core.Entities;
using Core.Utilities.Result;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ISensorRepository
    {
        IDataResult<List<Sensor>> GetSensors();
        IDataResult<Sensor> GetSensor(int id);
    }
}
