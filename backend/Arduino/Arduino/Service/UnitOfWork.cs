using Core.Interfaces;
using Core.Utilities;
using MySql.Data.MySqlClient;
using Service.Repositories;
using System;
using System.Data;
using System.Diagnostics;

namespace Service
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbTransaction transaction;
        IDbConnection connection;

        IDeviceDetailRepository _deviceDetail;
        IDeviceRepository _device;
        IDeviceTypeRepository _deviceType;
        IPinRepository _pin;
        ISensorRepository _sensor;
        IUserRepository _user;

        bool disposed;

        public IDeviceDetailRepository DeviceDetail
        {
            get
            {
                return _deviceDetail ?? (_deviceDetail = new DeviceDetailRepository(transaction));
            }
        }

        public IDeviceRepository Device
        {
            get
            {
                return _device ?? (_device = new DeviceRepository(transaction));
            }
        }

        public IDeviceTypeRepository DeviceType
        {
            get
            {
                return _deviceType ?? (_deviceType = new DeviceTypeRepository(transaction));
            }
        }

        public IPinRepository Pin
        {
            get
            {
                return _pin ?? (_pin = new PinRepository(transaction));
            }
        }

        public ISensorRepository Sensor
        {
            get
            {
                return _sensor ?? (_sensor = new SensorRepository(transaction));
            }
        }

        public IUserRepository User
        {
            get
            {
                return _user ?? (_user = new UserRepository(transaction));
            }
        }

        public UnitOfWork()
        {
            try
            {
                ConnectionInfo connectionInfo = ConnectionInfo.Instance;
                connection = new MySqlConnection(connectionInfo.MySQLConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex);
            }
        }



        public bool Commit()
        {
            bool rtn = false;
            try
            {
                transaction.Commit();
                rtn = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
                transaction = connection.BeginTransaction();
                resetRepositories();
            }
            return rtn;
        }


        public bool Rollback()
        {
            bool rtn = false;
            try
            {
                transaction?.Rollback();
                rtn = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                transaction?.Dispose();
                transaction = connection.BeginTransaction();
                resetRepositories();
            }
            return rtn;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void resetRepositories()
        {
             _deviceDetail = null;
             _device = null;
             _deviceType = null;
             _pin = null;
             _sensor = null;
             _user = null;
        }

        private void dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }

                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
                disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
