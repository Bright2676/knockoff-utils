﻿using Exiled.Events.EventArgs.Player;
using Exiled.Permissions.Extensions;

namespace CactusPatchExample
{
    internal sealed class ServerHandler
    {
        public void Verified(VerifiedEventArgs ev)
        {
            ev.Player.Broadcast(5, Class1.Instance.Config.OnJoinMsg);
        }
    }
}
