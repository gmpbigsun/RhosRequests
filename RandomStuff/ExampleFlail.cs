using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RhosRequests.RandomStuff
{
	public class ExampleFlail : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.White;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 40;
			Item.useTime = 40;
			Item.knockBack = 4f;
			Item.damage = 9;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<ExampleFlailProjectile>();
			Item.shootSpeed = 15.1f;
			Item.UseSound = SoundID.Item1;
			Item.crit = 9;
			Item.channel = true;
		}


	}
}
