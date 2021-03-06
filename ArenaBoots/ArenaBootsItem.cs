using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace RhosRequests.ArenaBoots
{
    public class ArenaBootsItem : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<RhosRequestsConfig>().EnableArenaBoots;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Provides the ability to place platforms as you walk.\nEnable this item (default 'p') under controls."); // The (English) text shown below your item's name
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

            if (heldItem.netID == 0)
                return;

            bool groundCheck = ModContent.GetInstance<RhosRequestsConfig>().EnableGroundCheckArenaBoots ? Main.LocalPlayer.velocity.Y == 0 && Main.LocalPlayer.oldVelocity.Y == 0 : true;
            bool allowBuildingBlock = ModContent.GetInstance<RhosRequestsConfig>().EnableBuildingBlocksArenaBoots ? heldItem.createTile == TileID.Stone || heldItem.createTile == TileID.Dirt || heldItem.createTile == TileID.WoodBlock : false;

            if (Main.LocalPlayer.GetModPlayer<ArenaBootsPlayer>().isOn && heldItem.maxStack > 1 && (heldItem.createTile == TileID.Platforms || allowBuildingBlock) && groundCheck)
            {
                Point tileLocationBottom = new Vector2(Main.LocalPlayer.Center.X, Main.LocalPlayer.position.Y + 48f).ToTileCoordinates();
                int tileToPlace = heldItem.createTile;

                PlaceTile(tileLocationBottom, heldItem, tileToPlace);

                if (Main.LocalPlayer.direction == -1 && heldItem.stack > 0)
                {
                    Point tileLocationBottomLeft = new Vector2(Main.LocalPlayer.Center.X - 16, Main.LocalPlayer.position.Y + 48f).ToTileCoordinates();
                    PlaceTile(tileLocationBottomLeft, heldItem, tileToPlace);
                }
                else if (Main.LocalPlayer.direction == 1 && heldItem.stack > 0)
                {
                    Point tileLocationBottomRight = new Vector2(Main.LocalPlayer.Center.X + 16, Main.LocalPlayer.position.Y + 48f).ToTileCoordinates();
                    PlaceTile(tileLocationBottomRight, heldItem, tileToPlace);
                }
            }
        }

        private static void PlaceTile(Point tilePosition, Item heldItem, int tileToPlace)
        {
            if (WorldGen.PlaceTile(tilePosition.X, tilePosition.Y, tileToPlace, false, false, style: heldItem.placeStyle) && heldItem.stack > 0)
            {
                heldItem.stack--;
                if (Main.netMode != NetmodeID.SinglePlayer)
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, tilePosition.X, tilePosition.Y, tileToPlace);
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "ItemName", "Arena Boots");
            tooltips[0] = line;
            base.ModifyTooltips(tooltips);
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.HermesBoots, 1)
                .AddIngredient(ItemID.Wire, 20)
                .AddRecipeGroup("RhosRequests:Platforms", 250)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
