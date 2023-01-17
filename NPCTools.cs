using Terraria;
using System.Linq;
using Terraria.ID;

namespace DarkestDungeonNarration
{
    public static class NPCTools
    {
        public static bool IsAnyBossActive()
        {
            return Main.npc.Take(Main.maxNPCs).Any(n => n.active && n.boss);
        }

        public static bool IsAnyOtherBossActive(NPC npc)
        {
            return Main.npc.Take(Main.maxNPCs).Any(n => n.active && n.boss && n != npc);
        }

        public static bool IsBossSlime(int type)
        {
            return type == NPCID.KingSlime || type == NPCID.QueenSlimeBoss;
        }

        public static bool IsBossMechanical(int type)
        {
            return
                /* Twins */ type == NPCID.Retinazer || type == NPCID.Spazmatism ||
                /* Destroyer */ type == NPCID.TheDestroyer || type == NPCID.TheDestroyerBody || type == NPCID.TheDestroyerTail ||
                /* Skeletron Prime */ type == NPCID.SkeletronPrime;
        }
    }
}
