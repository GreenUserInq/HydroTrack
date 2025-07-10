using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroTrack.Models
{
    public class MqttSettings
    {
        public string BrokerAddress { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public Dictionary<string, string> Topics { get; set; } = new();
    }

    public class AppConfig
    {
        public MqttSettings MqttSettings { get; set; } = new();
    }
}
