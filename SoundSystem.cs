using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkestDungeonNarration
{
    public class SoundSystem : ModSystem
    {
        // Directories
        private const string RootDir = $"{nameof(DarkestDungeonNarration)}/Sounds/";

        private const string BossFightStartDir = RootDir + "BossFightStarts/";
        private const string BossLowHealthDir = RootDir + "BossLowHealth/";
        private const string DieDuringBossFightDir = RootDir + "DieDuringBossFight/";
        private const string LoseBossFightDir = RootDir + "LoseBossFight/";
        private const string TeammateDiesDuringBossFightDir = RootDir + "TeammateDiesDuringBossFight/";
        private const string WinBossFightDir = RootDir + "WinBossFight/";
        private const string HealDuringBossFightDir = RootDir + "HealDuringBossFight/";
        private const string RespawnDuringBossFightDir = RootDir + "RespawnDuringBossFight/";
        private const string TeammateRespawnsDuringBossFightDir = RootDir + "TeammateRespawnsDuringBossFight/";

        // Queue sounds so they don't overlap
        // Max size 3 to prevent millions of sounds happening in succession
        private LimitedQueue<SoundStyle> soundQueue = new(3);
        private int time = 0;
        private const int DelayMax = 60 * 6;

        public override void PostUpdateEverything()
        {
            time++;
            if (time < DelayMax || soundQueue.Count == 0) return;

            time = 0;
            SoundEngine.PlaySound(soundQueue.Dequeue());
        }

        public void PlayBossStart(int type)
        {
            if (NPCTools.IsBossSlime(type))
            {
                soundQueue.Enqueue(new SoundStyle(BossFightStartDir + "slime"));
            }
            else if (NPCTools.IsBossMechanical(type))
            {
                soundQueue.Enqueue(new SoundStyle(BossFightStartDir + "mechanical_", 3));
            }
            else
            {
                soundQueue.Enqueue(new SoundStyle(BossFightStartDir, 3));
            }
        }

        public void PlayBossLowHealth()
        {
            soundQueue.Enqueue(new SoundStyle(BossLowHealthDir, 6));
        }

        public void PlayDeathDuringBossFight()
        {
            soundQueue.Enqueue(new SoundStyle(DieDuringBossFightDir, 7));
        }
        
        public void PlayLoseBossFight()
        {
            soundQueue.Enqueue(new SoundStyle(LoseBossFightDir, 13));
        }

        public void PlayTeammateDiesDuringBossFight()
        {
            soundQueue.Enqueue(new SoundStyle(TeammateDiesDuringBossFightDir, 4));
        }
        
        public void PlayWinBossFight()
        {
            soundQueue.Enqueue(new SoundStyle(WinBossFightDir, 21));
        }

        public void PlayUseHealDuringBossFight()
        {
            soundQueue.Enqueue(new SoundStyle(HealDuringBossFightDir, 5));
        }

        public void PlayRespawnDuringBossFight()
        {
            soundQueue.Enqueue(new SoundStyle(RespawnDuringBossFightDir, 4));
        }

        public void PlayTeammateRespawnsDuringBossFight()
        {
            soundQueue.Enqueue(new SoundStyle(TeammateRespawnsDuringBossFightDir, 2));
        }
    }
}
