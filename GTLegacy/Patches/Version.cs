using HarmonyLib;
using PlayFab;
using PlayFab.ClientModels;
using GorillaNetworking;
using System.Reflection;
using UnityEngine;

namespace GTLegacy.Patches
{
    [HarmonyPatch(typeof(GorillaComputer), "OnReturnCurrentVersion")]
    class Version
    {
        static bool Prefix(ExecuteCloudScriptResult result)
        {
            return false;
        }
    }
}