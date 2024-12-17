using Exiled.API.Interfaces;
using Exiled.API.Features;

namespace CactusPatchExample
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool MtfTriggerTeslas { get; set; } = false;
        public string OnJoinMsg { get; set; } = "Welcome to <color=green>The Cactus Patch</color>, enjoy your stay!"; // html counts here
    }
}
