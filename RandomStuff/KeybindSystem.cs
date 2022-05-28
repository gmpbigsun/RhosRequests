using Terraria.ModLoader;

namespace RhosRequests.RandomStuff
{
    public class KeybindSystem : ModSystem
    {
        public static ModKeybind ToggleArenaBoots { get; private set; }

        public override void Load()
        {
            ToggleArenaBoots = KeybindLoader.RegisterKeybind(Mod, "Toggle Arena Boots", "P");
        }

        public override void Unload()
        {
            ToggleArenaBoots = null;
        }
    }
}
