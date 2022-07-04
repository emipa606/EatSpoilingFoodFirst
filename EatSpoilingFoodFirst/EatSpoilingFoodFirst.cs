using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace EatSpoilingFoodFirst
{
    
    [StaticConstructorOnStartup]
    public static class EatSpoilingFoodFirst
    {
        static EatSpoilingFoodFirst()
        {
            Log.Message("EatSpoilingFoodFirst StartUp");
            var harmony = new Harmony("com.eat.spoiling.food.first.patch");
            harmony.PatchAll(); // todo patch only created methods
        }
    }
    
    [HarmonyPatch(typeof(FoodUtility))]
    [HarmonyPatch(nameof(FoodUtility.FoodOptimality))]
    static class FoodUtility_FoodOptimality_Patch
    {
        static void Postfix(
            Pawn eater,
            Thing foodSource,
            ThingDef foodDef,
            float dist,
            bool takingToInventory,
            ref float __result)
        {
            // __result is the harmony variable called num returned by FoodOptimality vanilla function
            // __result represent the FoodOptimality value that determine what food will eaten according to dist, food optimality offset value and belief offset 
            if(!eater.RaceProps.Humanlike || !eater.Faction.IsPlayer)return;  // only human or player faction eater (colonist, prisoner, slave, animals)
            float original = __result;
            CompRottable comp = foodSource.TryGetComp<CompRottable>();
            if (comp != null)  
            {
                // in vanilla FoodOptimality function : TicksUntilRotAtCurrentTemp < 30000 tick adds a modifier of +12f then 1 tick equal +0.0004f modifier  (30000 tick = 12h in game time = 8m 20s real time)
                if (!takingToInventory && comp.Stage == RotStage.Fresh && comp.TicksUntilRotAtCurrentTemp < 30000)__result -= 12f;  // remove vanilla offset
                // if we want to check freshness in 24h range and respect vanilla modifier logic, our multiplier needs to be 0.0002f for 60000 tick max
                // if (!takingToInventory && comp.Stage == RotStage.Fresh && comp.TicksUntilRotAtCurrentTemp < 60000)__result += 12f - (comp.TicksUntilRotAtCurrentTemp * 0.0002f);
                if (!takingToInventory && comp.Stage == RotStage.Fresh && comp.TicksUntilRotAtCurrentTemp < 180000)__result += 18f - (comp.TicksUntilRotAtCurrentTemp * 0.0001f);  // checking for 3 days freshness and a max + 18 modifier

                // Log.Message("FoodOptimality debug (eater:" + eater.Name + "/food:" + foodDef.defName + ") : original =" + original + " result =" + __result + " bonus offset =" + (Math.Abs(__result) - Math.Abs(original)) + " TicksUntilRotAtCurrentTemp = " + comp.TicksUntilRotAtCurrentTemp);
            }
        }
    }
}
