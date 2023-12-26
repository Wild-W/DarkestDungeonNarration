using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;

namespace DarkestDungeonNarration
{
    public class NarrationConfig : ModConfig
    {
        private const string LocalizationPath = $"Mods.{nameof(DarkestDungeonNarration)}.{nameof(NarrationConfig)}";

        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("General")]

        [LabelKey($"${LocalizationPath}.Volume.Label")]
        [TooltipKey($"${LocalizationPath}.Volume.Tooltip")]
        [DefaultValue(10)]
        [Slider]
        [Range(0, 10)]
        [Increment(1)]
        public int Volume;

        [Header($"${LocalizationPath}.NarratorLines")]

        [LabelKey($"${LocalizationPath}.BossStart")]
        [TooltipKey($"${LocalizationPath}.BossStart.Tooltip")]
        [DefaultValue(true)]
        public bool BossStart;

        [LabelKey($"${LocalizationPath}.BossLowHealth")]
        [TooltipKey($"${LocalizationPath}.BossLowHealth.Tooltip")]
        [DefaultValue(true)]
        public bool BossLow;

        [LabelKey($"${LocalizationPath}.DieDuringBoss")]
        [TooltipKey($"${LocalizationPath}.DieDuringBoss.Tooltip")]
        [DefaultValue(true)]
        public bool DieDuringBoss;

        [LabelKey($"${LocalizationPath}.LoseBossFight")]
        [TooltipKey($"${LocalizationPath}.LoseBossFight.Tooltip")]
        [DefaultValue(true)]
        public bool LoseToBoss;

        [LabelKey($"${LocalizationPath}.TeammateDeathDuringBoss")]
        [TooltipKey($"${LocalizationPath}.TeammateDeathDuringBoss.Tooltip")]
        [DefaultValue(true)]
        public bool TeammateDieDuringBoss;

        [LabelKey($"${LocalizationPath}.WinAgainstBoss")]
        [TooltipKey($"${LocalizationPath}.WinAgainstBoss.Tooltip")]
        [DefaultValue(true)]
        public bool BossWin;

        [LabelKey($"${LocalizationPath}.HealDuringBoss")]
        [TooltipKey($"${LocalizationPath}.HealDuringBoss.Tooltip")]
        [DefaultValue(true)]
        public bool HealDuringBoss;

        [LabelKey($"${LocalizationPath}.RespawnInBossFight")]
        [TooltipKey($"${LocalizationPath}.RespawnInBossFight.Tooltip")]
        [DefaultValue(true)]
        public bool RespawnDuringBoss;

        [LabelKey($"${LocalizationPath}.TeammateRespawnDuringBoss")]
        [TooltipKey($"${LocalizationPath}.TeammateRespawnDuringBoss.Tooltip")]
        [DefaultValue(true)]
        public bool TeammateRespawnDuringBoss;
    }
}
