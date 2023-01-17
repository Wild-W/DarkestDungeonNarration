using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;

namespace DarkestDungeonNarration
{
    public class NarrationConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("General")]

        [Label("Volume")]
        [Tooltip("Volume of the narrator")]
        [DefaultValue(10)]
        [Slider]
        [Range(0, 10)]
        [Increment(1)]
        public int Volume;

        [Header("Narrator Lines")]

        [Label("Boss Start")]
        [Tooltip("Whether to play boss start sounds")]
        [DefaultValue(true)]
        public bool BossStart;

        [Label("Boss Low Health")]
        [Tooltip("Whether to play boss low health (50% hp) sounds")]
        [DefaultValue(true)]
        public bool BossLow;

        [Label("Die During Boss")]
        [Tooltip("Whether to play sounds when dying during a boss fight")]
        [DefaultValue(true)]
        public bool DieDuringBoss;

        [Label("Lose Boss Fight")]
        [Tooltip("Whether to play sounds when losing a boss fight")]
        [DefaultValue(true)]
        public bool LoseToBoss;

        [Label("Teammate Death During Boss")]
        [Tooltip("Whether to play teammate dies to boss sounds")]
        [DefaultValue(true)]
        public bool TeammateDieDuringBoss;

        [Label("Win Against Boss")]
        [Tooltip("Whether to play sounds when killing a boss")]
        [DefaultValue(true)]
        public bool BossWin;

        [Label("Heal During Boss")]
        [Tooltip("Whether to play sounds when you heal during a boss fight")]
        [DefaultValue(true)]
        public bool HealDuringBoss;

        [Label("Respawn In Boss Fight")]
        [Tooltip("Whether to play sounds when you respawn during a boss fight")]
        [DefaultValue(true)]
        public bool RespawnDuringBoss;

        [Label("Teammate Respawn During Boss")]
        [Tooltip("Whether to play sounds when a teammate respawns during a boss fight")]
        [DefaultValue(true)]
        public bool TeammateRespawnDuringBoss;
    }
}
