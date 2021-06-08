using Core.Entities;
using Core.Interfaces;
using Core.Utilities;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Service.Repositories
{
    public class SensorRepository : BaseRepository, ISensorRepository
    {
        public SensorRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IDataResult<Sensor> GetSensor(int id)
        {
            string sql = "SELECT * FROM sensor WHERE Id = @id AND Status = 1";
            var result = connection.ExecuteCommand<Sensor>(sql, id)?.FirstOrDefault();
            if (result != null)
                return new SuccessDataResult<Sensor>(result);
            return new ErrorDataResult<Sensor>(null, Messages.Sensor.NotFound);
        }

        public IDataResult<List<Sensor>> GetSensors()
        {
            string sql = "SELECT * FROM sensor WHERE Status = 1";
            var sensors = connection.ExecuteCommand<Sensor>(sql).ToList();
            return new SuccessDataResult<List<Sensor>>(sensors);
        }
    }
}
