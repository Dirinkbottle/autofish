using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;
using StardewModdingAPI;
using StardewValley.Tools;
using StardewValley.Menus;
namespace autofish
{
    /*isFishing bool 是否在钓鱼 fishingrod
timeUntilFishingBite  float 鱼上钩时间fishingrod
fishSize int 鱼的长度 bobberbar
distanceFromCatching float 钓鱼进度条bobberbar
 fishQuality int 钓鱼品质bobberbar*/
    internal class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.Display.MenuChanged += Display_MenuChanged;
            helper.Events.GameLoop.UpdateTicked += GameLoop_UpdateTicked;
        }

        private void GameLoop_UpdateTicked(object? sender, StardewModdingAPI.Events.UpdateTickedEventArgs e)
        {
            if (Game1.player.CurrentTool is FishingRod fishingRod && this.Helper.Reflection.GetField<bool>(fishingRod, "isFishing",true).GetValue())
            {
                this.Helper.Reflection.GetField<float>(fishingRod, "timeUntilFishingBite",true).SetValue(0f);
            }
        }

        private void Display_MenuChanged(object? sender, StardewModdingAPI.Events.MenuChangedEventArgs e)
        {
            if (e.NewMenu is BobberBar bobberBar && Game1.player.CurrentTool is FishingRod fishingRod)
            {
                this.Helper.Reflection.GetField<int>(bobberBar, "fishQuality", true).SetValue(2);
                this.Helper.Reflection.GetField<int>(bobberBar, "fishSize", true).SetValue(9999);
                this.Helper.Reflection.GetField<float>(bobberBar, "distanceFromCatching", true).SetValue(1f);
              
            }
        }
    }
}
