using System;
using Harmony;
using UnhollowerBaseLib;
using UnityEngine;

namespace BeachcombingAdjustments
{
    internal class Patches
    {
        private const string IMPROVISED_KNIFE_NAME = "GEAR_KnifeImprovised";
        private const string BROKEN_ARROW_NAME = "GEAR_BrokenArrow";
        private const string FLARE_SHELL_NAME = "GEAR_FlareGunAmmoSingle";
        private const string RIFLE_NAME = "GEAR_Rifle";
        private const string REVOLVER_NAME = "GEAR_Revolver";
        private const string REVOLVER_AMMO_NAME = "GEAR_RevolverAmmoSingle";
        private const string COFFEE_NAME = "GEAR_CoffeeTin";
        private const string HERBAL_TEA_NAME = "GEAR_GreenTeaPackage";
        private const string E_STIM_NAME = "GEAR_EmergencyStim";
        private const string REISHI_NAME = "GEAR_ReishiMushroom";
        private const string ROSE_HIPS_NAME = "GEAR_RoseHip";
        private const string LOOT_TABLE_NAME = "LootTableTideLine";

        [HarmonyPatch(typeof(LootTable), "DisableForXPMode")]
        private static class enableItemsOnInterloper
        {
            internal static void Postfix(LootTable __instance, GameObject go, ref bool __result)
            {
                if (__instance.name == LOOT_TABLE_NAME)
                {
                    if (Settings.options.knifeOnInterloper && go.name == IMPROVISED_KNIFE_NAME)
                    {
                        __result = false;
                    }
                    else if (Settings.options.brokenArrowOnInterloper && go.name == BROKEN_ARROW_NAME)
                    {
                        __result = false;
                    }
                    else if (Settings.options.flareShellOnInterloper && go.name == FLARE_SHELL_NAME)
                    {
                        __result = false;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(LootTable),"GetRandomGearPrefab")]
        private static class addNormalItems
        {
            internal static void Prefix(LootTable __instance)
            {
                if(__instance.name == LOOT_TABLE_NAME)
                {
                    LootTableUtils.AddOrRemoveEntryFromLootTable(__instance, Settings.options.reishiMushrooms, REISHI_NAME, 6);
                    LootTableUtils.AddOrRemoveEntryFromLootTable(__instance, Settings.options.roseHips, ROSE_HIPS_NAME, 9);
                    LootTableUtils.AddOrRemoveEntryFromLootTable(__instance, Settings.options.rifle, RIFLE_NAME, 1);
                    LootTableUtils.AddOrRemoveEntryFromLootTable(__instance, Settings.options.revolver, REVOLVER_NAME, 1);
                    LootTableUtils.AddOrRemoveEntryFromLootTable(__instance, Settings.options.revolverAmmo, REVOLVER_AMMO_NAME, 3);
                    LootTableUtils.AddOrRemoveEntryFromLootTable(__instance, Settings.options.coffee, COFFEE_NAME, 1);
                    LootTableUtils.AddOrRemoveEntryFromLootTable(__instance, Settings.options.herbalTea, HERBAL_TEA_NAME, 1);
                    LootTableUtils.AddOrRemoveEntryFromLootTable(__instance, Settings.options.estim, E_STIM_NAME, 1);
                }
            }
        }
    }
}