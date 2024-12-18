using Exiled.API.Interfaces;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace KnockoffUtils
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool MtfTriggerTeslas { get; set; } = false;
        public string OnJoinMsg { get; set; } = "This server is currently using <color=lime>Knockoff Utils</color>. Have a good day!"; // html counts here
        public ushort AmmoOnSpawn { get; set; } = 41; // set to 0 if you don't want anyone to spawn with excess ammo
        public bool InventoryKeycards { get; set; } = true; // if keycard required objects see your keycard as 'open' even when its in your inventory
        public bool PinkCandy { get; set; } = true; // enable pink candy or not
    }
}
