using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace AllahAkbar
{
    public class Handlers
    {
        public static IEnumerator<float> AkbarAllah(Player player, float speed)
        {
            const int maxAmnt = 50;
            int amnt = 0;
            while (player.Role != RoleType.Spectator)
            {
                player.Position += Vector3.up * speed;
                amnt++;
                if (amnt >= maxAmnt)
                {
                    player.IsGodModeEnabled = false;
                    player.Kill();
                }

                yield return Timing.WaitForOneFrame;
            }
        }

        public void OnJumping(SyncingDataEventArgs ev)
        {
            if (ev.Player.CurrentAnimation == ev.CurrentAnimation) return;

            if (ev.Player.IsJumping)
            {
                Timing.RunCoroutine(AkbarAllah(ev.Player, 2.5f));
                Map.Broadcast(Allah.Singleton.Config.BroadcastDeath.Duration, Allah.Singleton.Config.BroadcastDeath.Content.Replace("{player}", ev.Player.Nickname), Broadcast.BroadcastFlags.Normal, true);
            }
        }
    }
}