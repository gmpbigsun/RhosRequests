using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace RhosRequests
{
    public class RhosRequests : ModConfig
    {
        // ConfigScope.ClientSide should be used for client side, usually visual or audio tweaks.
        // ConfigScope.ServerSide should be used for basically everything else, including disabling items or changing NPC behaviours
        public override ConfigScope Mode => ConfigScope.ServerSide;
        
        [Header("Arena Boots")] 
        [Label("Enable Arena Boots")] 
        [Tooltip("This system places platforms you hold automatically as you walk")] 
        [DefaultValue(false)] 
        [ReloadRequired] 
        public bool EnableArenaBoots;

        [Label("Enable GroundCheck")]
        [Tooltip("This allows you to only be able to place platforms when standing on tiles")]
        [DefaultValue(true)]
        public bool EnableGroundCheckArenaBoots;

        [Label("Allow Stone, Dirt and Wood Blocks")]
        [Tooltip("This allows you to place specific buildings blocks beside platforms")]
        [DefaultValue(false)]
        public bool EnableBuildingBlocksArenaBoots;
    }
}