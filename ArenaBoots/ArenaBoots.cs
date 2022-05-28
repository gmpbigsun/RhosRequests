using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using RhosRequests.Helper;

namespace RhosRequests.ArenaBoots
{
    public class ArenaBoots : Mod
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Platform", ItemGroups.platforms);
            RecipeGroup.RegisterGroup("RhosRequests:Platforms", group);
        }
    }
}
