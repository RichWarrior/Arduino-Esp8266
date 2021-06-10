using Core.Entities;
using Core.Interfaces;
using Core.Utilities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arduino.API.Hubs
{
    public class SensorHub : Hub
    {
        IUnitOfWork uow;

        User user = null;

        public SensorHub(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var query = httpContext.Request.QueryString.Value.Split('?', '&').ToList();
            query.RemoveAll(f => String.IsNullOrEmpty(f));
            IDictionary<string, string> headers = new Dictionary<string, string>();
            foreach (var q in query)
            {
                var pieces = q.Split('=');
                headers.Add(pieces[0], pieces[1]);
            }
            if(headers.TryGetValue("token",out string token))
            {
            httpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
                var userId =JWTManager.GetUserId(httpContext, uow);
                user = JWTManager.GetUser(userId, uow);
                if(user == null)
                {
                    Context.Abort();
                    return;
                }

                if(headers.TryGetValue("sensorId",out string sensorId))
                {
                    var sensor = uow.DeviceDetail.GetDeviceDetail(int.Parse(sensorId));
                    if (!sensor.Success)
                    {
                        Context.Abort();
                        return;
                    }

                    var sensorDetail = sensor.Data;
                    var deviceId = sensorDetail.DeviceId;
                    var device = uow.Device.FindById(deviceId);
                    if(!device.Success)
                    {
                        Context.Abort();
                        return;
                    }

                    var deviceItem = device.Data;
                    if(deviceItem.UserId != user.Id)
                    {
                        Context.Abort();
                        return;
                    }

                    Groups.AddToGroupAsync(Context.ConnectionId, sensorDetail.Id.ToString());
                }
                else
                {
                    Context.Abort();
                    return;
                }
                
            }
            else
            {
                Context.Abort();
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
        }
    }
}
