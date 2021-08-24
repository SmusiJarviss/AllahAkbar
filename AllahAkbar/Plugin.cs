using Exiled.API.Features;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace AllahAkbar
{
    public class Allah : Plugin<Config>
    {
        public Handlers Handlers { get; private set; }

        public static Allah Singleton;
        public override void OnEnabled()
        {
            Singleton = this;

            if (!Singleton.Config.IsEnabled)
                return;

            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {

            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            Handlers = new Handlers();
            PlayerEvents.SyncingData += Handlers.OnJumping;
        }

        private void UnregisterEvents()
        {
            PlayerEvents.SyncingData -= Handlers.OnJumping;
            Handlers = null;
        }
    }
}