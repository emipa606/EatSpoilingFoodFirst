using System.Reflection;
using HarmonyLib;
using Verse;

namespace EatSpoilingFoodFirst;

[StaticConstructorOnStartup]
public static class EatSpoilingFoodFirst
{
    static EatSpoilingFoodFirst()
    {
        new Harmony("com.eat.spoiling.food.first.patch").PatchAll(Assembly.GetExecutingAssembly());
    }
}