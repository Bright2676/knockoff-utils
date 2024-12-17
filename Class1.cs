global using Exiled.API.Enums;
global using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;

namespace CactusPatchExample
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
            Log.Info("im alive");
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
        }

        private void UnregisterEvents()
        {
            ServerHandler = null;
            PlayerHandler = null;

            Exiled.Events.Handlers.Player.Verified -= ServerHandler.Verified;
            Exiled.Events.Handlers.Player.TriggeringTesla -= PlayerHandler.OnTriggeringTesla;
        }

    }
}
