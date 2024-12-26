using Exiled.API.Enums;
using Exiled.API.Features;
using KnockoffUtils.EventHandlers;
using Exiled.Events.Handlers;

namespace KnockoffUtils
{
    public class Class1 : Plugin<Config>
    {
        public static Class1 Instance;
        private ServerHandler ServerHandler;
        private PlayerHandler PlayerHandler;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();

            Log.Info("Ready!");

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            Instance = null;

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            ServerHandler = new ServerHandler();
            PlayerHandler = new PlayerHandler();

            Exiled.Events.Handlers.Player.Verified += ServerHandler.Verified;
            Exiled.Events.Handlers.Player.TriggeringTesla += PlayerHandler.OnTriggeringTesla;
            Exiled.Events.Handlers.Player.Spawned += PlayerHandler.OnSpawned;
            Scp330.InteractingScp330 += PlayerHandler.OnInteractingScp330;
        }

        private void UnregisterEvents()
        {
            ServerHandler = null;
            PlayerHandler = null;

            Exiled.Events.Handlers.Player.Verified -= ServerHandler.Verified;
            Exiled.Events.Handlers.Player.TriggeringTesla -= PlayerHandler.OnTriggeringTesla;
            Exiled.Events.Handlers.Player.Spawned -= PlayerHandler.OnSpawned;
            Scp330.InteractingScp330 -= PlayerHandler.OnInteractingScp330;
        }

    }
}
