using System;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDeviceDetailRepository DeviceDetail { get; }

        IDeviceRepository Device { get; }

        IDeviceTypeRepository DeviceType { get; }

        IPinRepository Pin { get; }

        ISensorRepository Sensor { get; }

        IUserRepository User { get; }

        bool Commit();
        bool Rollback();
    }
}
