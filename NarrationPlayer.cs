using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DarkestDungeonNarration
{
    // Each instance of this class runs client side, so most operations handled here first ensure the player is also the local player, to not play duplicate or unintended sounds.
    public class NarrationPlayer : ModPlayer
    {
        public bool playDefeatOnSpawnIfNoBossActive = false;

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            // Only continue if in a boss fight
            if (!NPCTools.IsAnyBossActive()) return;

            playDefeatOnSpawnIfNoBossActive = true;

            // Client dies
            if (Player == Main.LocalPlayer)
            {
                ModContent.GetInstance<SoundSystem>().PlayDeathDuringBossFight();
            }
            // Teammate dies
            else
            {
                ModContent.GetInstance<SoundSystem>().PlayTeammateDiesDuringBossFight();
            }
        }

        // Losing boss fight actually refers to dying when a boss is active, and respawning when no boss is active
        // This is a problem because dying isn't the only way to "lose" to a boss (it can despawn too)
        // Hopefully, I'll be able to come back and fix this
        public override void OnRespawn()
        {
            // Client respawns
            if (Player == Main.LocalPlayer)
            {
                if (NPCTools.IsAnyBossActive())
                {
                    ModContent.GetInstance<SoundSystem>().PlayRespawnDuringBossFight();
                }
                else if (playDefeatOnSpawnIfNoBossActive)
                {
                    ModContent.GetInstance<SoundSystem>().PlayLoseBossFight();
                    playDefeatOnSpawnIfNoBossActive = false;
                }
            }
            // Teammate respawns during boss fight
            else if (NPCTools.IsAnyBossActive())
            {
                ModContent.GetInstance<SoundSystem>().PlayTeammateRespawnsDuringBossFight();
            }
        }
    }
}
