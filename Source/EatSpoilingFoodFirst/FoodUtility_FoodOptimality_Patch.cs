using HarmonyLib;
using RimWorld;
using Verse;

namespace EatSpoilingFoodFirst;

[HarmonyPatch(typeof(FoodUtility))]
[HarmonyPatch("FoodOptimality")]
internal static class FoodUtility_FoodOptimality_Patch
{
    private static void Postfix(Pawn eater, Thing foodSource, bool takingToInventory, ref float __result)
    {
        if (eater.Faction == null || !eater.RaceProps.Humanlike && !eater.Faction.IsPlayer)
        {
            return;
        }

        if (takingToInventory)
        {
            return;
        }

        var compRottable = foodSource.TryGetComp<CompRottable>();
        if (compRottable == null)
        {
            return;
        }

        if (compRottable.Stage != RotStage.Fresh)
        {
            return;
        }

        if (compRottable.TicksUntilRotAtCurrentTemp < GenDate.TicksPerDay / 2)
        {
            __result -= 12f;
        }

        if (compRottable.TicksUntilRotAtCurrentTemp < GenDate.TicksPerDay * 3)
        {
            __result += 18f - (compRottable.TicksUntilRotAtCurrentTemp * 0.0001f);
        }
    }
}