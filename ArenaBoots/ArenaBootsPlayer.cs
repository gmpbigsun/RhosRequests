using Terraria;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.ModLoader;
using RhosRequests.RandomStuff;

namespace RhosRequests.ArenaBoots
{
    public class ArenaBootsPlayer : ModPlayer
    {
        public bool isOn = false;
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (KeybindSystem.ToggleArenaBoots.JustPressed)
            {
                if (isOn == false)
                {
                    isOn = true;
                    Main.NewText($"Arena Boots enabled");
                }
                else
                {
                    isOn = false;
                    Main.NewText($"Arena Boots disabled");
                }
            }
        }

    }
}
