using BepInEx;
using HarmonyLib;

namespace GTLegacy
{
    [BepInPlugin("Instel.GTLegacy", "GTLegacy", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        void Awake()
        {
            Harmony harmony = new Harmony("Instel.GTLegacy");
            harmony.PatchAll();
        }
    }
}
