using Exiled.API.Interfaces;
using System.ComponentModel;

namespace AllahAkbar
{
    public class Config : IConfig
    {
        [Description("Plugin enable/disable.")]
        public bool IsEnabled { get; set; } = true;

        public Exiled.API.Features.Broadcast BroadcastDeath { get; set; } = new Exiled.API.Features.Broadcast("{player} è stato preso a calci nel culo fino alla luna.", 5);
    }
}
