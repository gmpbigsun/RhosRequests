using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Net;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace RhosRequests.ArenaBoots
{
    public class ArenaBootsItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded Item."); // The (English) text shown below your item's name
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.HermesBoots);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed = 1.25f;
            player.maxRunSpeed = 1f;
            Item heldItem = Main.LocalPlayer.HeldItem;
            if (Main.LocalPlayer.GetModPlayer<ArenaBootsPlayer>().isOn && heldItem.maxStack > 1 && Main.LocalPlayer.velocity.Y == 0 && Main.LocalPlayer.oldVelocity.Y == 0 && heldItem.createTile == TileID.Platforms)
            {
                Point tileLocationBottom = new Vector2(Main.LocalPlayer.Center.X, Main.LocalPlayer.position.Y + 48f).ToTileCoordinates();
                int tileToPlace = heldItem.createTile;


                if (WorldGen.PlaceTile(tileLocationBottom.X, tileLocationBottom.Y, tileToPlace, false, false, style: heldItem.placeStyle) && heldItem.stack > 0)
                    heldItem.stack--;
                if (Main.LocalPlayer.direction == -1 && heldItem.stack > 0)
                {
                    Point tileLocationBottomLeft = new Vector2(Main.LocalPlayer.Center.X - 16, Main.LocalPlayer.position.Y + 48f).ToTileCoordinates();
                    if (WorldGen.PlaceTile(tileLocationBottomLeft.X, tileLocationBottomLeft.Y, tileToPlace, false, false, style: heldItem.placeStyle) && heldItem.stack > 0)
                        heldItem.stack--;
                }
                else if (Main.LocalPlayer.direction == 1 && heldItem.stack > 0)
                {
                    Point tileLocationBottomRight = new Vector2(Main.LocalPlayer.Center.X + 16, Main.LocalPlayer.position.Y + 48f).ToTileCoordinates();
                    if (WorldGen.PlaceTile(tileLocationBottomRight.X, tileLocationBottomRight.Y, tileToPlace, false, false, style: heldItem.placeStyle) && heldItem.stack > 0)
                        heldItem.stack--;
                }
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.HermesBoots, 1)
                .AddIngredient(ItemID.Wire, 20)
                .AddRecipeGroup("RhosRequests:Platforms")
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
