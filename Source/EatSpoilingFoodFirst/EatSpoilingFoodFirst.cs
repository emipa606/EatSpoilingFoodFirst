using HarmonyLib;
using Verse;

namespace EatSpoilingFoodFirst;

[StaticConstructorOnStartup]
public static class EatSpoilingFoodFirst
{
    static EatSpoilingFoodFirst()
    {
        Log.Message("[EatSpoilingFoodFirst]: StartUp");
        new Harmony("com.eat.spoiling.food.first.patch").PatchAll();
    }
}