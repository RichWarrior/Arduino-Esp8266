using Core.Entities;
using Core.Interfaces;
using Core.Utilities.Result;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Service.Repositories
{
    public class PinRepository : BaseRepository, IPinRepository
    {
        public PinRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IDataResult<List<Pin>> GetAvailablePins(int deviceId, int deviceTypeId)
        {
            string sql = @"
               SELECT * FROM pin p WHERE p.Id NOT IN 
              (
                  SELECT 
                  p.PinName
                  FROM devicedetail dd
                  INNER JOIN pin p ON p.Id = dd.PinId
                  WHERE dd.Status = 1 AND dd.DeviceId = @deviceId
              )
              AND p.IsDefault<> 1 AND p.DeviceTypeId = @deviceTypeId
            ";
            var result = connection.ExecuteCommand<Pin>(sql, deviceId, deviceTypeId).ToList();
            return new SuccessDataResult<List<Pin>>(result);
        }
    }
}
