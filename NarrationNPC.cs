using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DarkestDungeonNarration
{
    public class NarrationNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool hasReachedHalfHealth = false;

        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            if (!npc.boss) return;

            // Boss reaches half HP
            if (npc.life > 0 && !hasReachedHalfHealth && npc.life < npc.lifeMax / 2)
            {
                hasReachedHalfHealth = true;
                ModContent.GetInstance<SoundSystem>().PlayBossLowHealth();
            }
            // Victory against boss
            else if (npc.life <= 0)
            {
                ModContent.GetInstance<SoundSystem>().PlayWinBossFight();
            }
        }

        public override void OnKill(NPC npc)
        {
            if (!npc.boss || npc.life > 0) return;
            
            // Prevent defeat sound from playing because we won, even if some players died at the end
            foreach (Player player in Main.player)
            {
                player.GetModPlayer<NarrationPlayer>().playDefeatOnSpawnIfNoBossActive = false;
            }
        }

        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if (!npc.boss || NPCTools.IsAnyOtherBossActive(npc)) return;

            ModContent.GetInstance<SoundSystem>().PlayBossStart(npc.type);
        }
    }
}
