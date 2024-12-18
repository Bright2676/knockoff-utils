using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp330;
using InventorySystem.Items.Usables.Scp330;
using PlayerRoles;
using System;

namespace KnockoffUtils
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
        public void OnSpawned(SpawnedEventArgs ev)
        {
            if (ev.Player == null)
            {
                Log.Warn("Player object was null during spawn event.");
                return;
            }

            if (ev.Player.Role.Team == Team.ClassD)
            {
                ev.Player.Ammo[ItemType.Ammo762x39] = Class1.Instance.Config.AmmoOnSpawn;
            }
            else if (ev.Player.Role.Team == Team.Scientists)
            {
                ev.Player.Ammo[ItemType.Ammo556x45] = Class1.Instance.Config.AmmoOnSpawn;
            }
            else if (ev.Player.Role.Team == Team.Dead)
            {
                Log.Warn("Player spawned but has no alive team assigned.");
                return;
            }
            else
            {
                Log.Info("Player " + ev.Player.Nickname + " is not a D-Class or a Scientist");
            }
        }
        public void OnInteractingScp330(InteractingScp330EventArgs ev)
        {
            if (!Class1.Instance.Config.PinkCandy) return;
            try
            {
                if (UnityEngine.Random.Range(1, 100) <= 10)
                {
                    ev.Candy = CandyKindID.Pink;
                }

                ev.Player.ShowHint($"You picked up a {ev.Candy} candy!", 3);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in OnInteractingScp330: {ex}");
            }

        }
    }
}
