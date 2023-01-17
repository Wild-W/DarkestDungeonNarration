using Terraria;
using Terraria.ModLoader;

namespace DarkestDungeonNarration
{
    public class NarrationItem : GlobalItem
    {
        public override void OnConsumeItem(Item item, Player player)
        {
            if (NPCTools.IsAnyBossActive() && Main.LocalPlayer == player && item.healLife > 0)
            {
                ModContent.GetInstance<SoundSystem>().PlayUseHealDuringBossFight();
            }
        }
    }
}
