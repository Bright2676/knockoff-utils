using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace CactusPatchExample
{
    internal sealed class PlayerHandler
    {
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev) // for the mtf-disable-teslas thingy
        {
            if (ev.Player is null)
            {
                Log.Warn("No player found || OnTriggeringTesla();");
            }
            else
            {
                if (Class1.Instance.Config.MtfTriggerTeslas == true)
                {
                    if (ev.Player.Role.Team == PlayerRoles.Team.FoundationForces) // wait one sec yall
                    {
                        ev.IsInIdleRange = false; // now it might work
                        ev.IsTriggerable = false;
                    }
                }
            }
        }
    }
}
