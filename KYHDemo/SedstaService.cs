using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHDemo
{
        internal class SendDataService
        {
            public static async Task SendDataAsync(SensorData sensordata)
            {
                var thinkspeak = new Thinkspeak();
                await thinkspeak.SendDataAsync(sensordata);
            }
        }
    }
