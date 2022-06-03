using RhosRequests.Helper;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RhosRequests
{
    public class RhosRequests : Mod
    {
        public override void Load()
        {
            base.Load();
            if (ModContent.GetInstance<RhosRequestsConfig>().EnableDamageVariation)
            {
                On.Terraria.Main.DamageVar += (orig, damage, luck) => (int)Math.Round(damage * Main.rand.NextFloat(ModContent.GetInstance<RhosRequestsConfig>().IncMaxVariance / 100f, ModContent.GetInstance<RhosRequestsConfig>().DecMinVariance / 100f));
            }
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Platform", ItemGroups.platforms);
            RecipeGroup.RegisterGroup("RhosRequests:Platforms", group);
        }
    }
}
