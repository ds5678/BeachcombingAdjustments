using ModSettings;

namespace BeachcombingAdjustments
{
    internal class BeachcombingSettings : JsonModSettings
    {
        [Section("Interloper")]
        [Name("Improvised Knife on Interloper")]
        [Description("On interloper, improvised knives are disabled for beachcombing spawns by default.")]
        public bool knifeOnInterloper = false;

        [Name("Broken Arrow on Interloper")]
        [Description("On interloper, broken arrows are disabled for beachcombing spawns by default.")]
        public bool brokenArrowOnInterloper = false;

        [Name("Flare Shell on Interloper")]
        [Description("On interloper, flare shells are disabled for beachcombing spawns by default.")]
        public bool flareShellOnInterloper = false;

        [Section("All Game Modes")]
        [Name("Reishi Mushroom")]
        [Description("Adds reishi mushrooms to the loot table on all game modes")]
        public bool reishiMushrooms = false;

        [Name("Rose Hip")]
        [Description("Adds a single rose hip to the loot table on all game modes")]
        public bool roseHips = false;

        [Name("Rifle")]
        [Description("Rifles can spawn on shore if they're enabled in your game mode.")]
        public bool rifle = false;

        [Name("Revolver")]
        [Description("Revolvers can spawn on shore if they're enabled in your game mode.")]
        public bool revolver = false;

        [Name("Revolver Ammo")]
        [Description("Revolver cartridges can spawn on shore if revolvers are enabled in your game mode.")]
        public bool revolverAmmo = false;

        [Name("Coffee")]
        [Description("Adds tins of Coffee to the loot table on all game modes")]
        public bool coffee = false;

        [Name("Herbal Tea")]
        [Description("Adds boxes of Herbal Tea to the loot table on all game modes")]
        public bool herbalTea = false;

        [Name("E-Stims")]
        [Description("Adds E-Stims to the loot table on all game modes")]
        public bool estim = false;
    }
    internal static class Settings
    {
        public static BeachcombingSettings options;
        public static void OnLoad()
        {
            options = new BeachcombingSettings();
            options.AddToModSettings("Beachcombing Adjustments");
        }
    }
}