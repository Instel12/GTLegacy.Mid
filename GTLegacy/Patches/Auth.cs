using HarmonyLib;
using PlayFab;
using PlayFab.ClientModels;
using GorillaNetworking;
using System.Reflection;
using UnityEngine;

namespace GTLegacy.Patches
{
    [HarmonyPatch(typeof(PlayFabAuthenticator), nameof(PlayFabAuthenticator.AuthenticateWithPlayFab))]
    class Auth
    {
        static bool Prefix(PlayFabAuthenticator __instance)
        {
            MethodInfo requestPhotonToken = typeof(PlayFabAuthenticator).GetMethod("RequestPhotonToken", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo onPlayFabError = typeof(PlayFabAuthenticator).GetMethod("OnPlayFabError", BindingFlags.Instance | BindingFlags.NonPublic);

            PlayFabClientAPI.LoginWithCustomID(
                new LoginWithCustomIDRequest
                {
                    CreateAccount = true,
                    CustomId = SystemInfo.deviceUniqueIdentifier
                },
                (LoginResult result) => {requestPhotonToken.Invoke(__instance, new object[] { result });},
                (PlayFabError error) => {onPlayFabError.Invoke(__instance, new object[] { error });}
            );

            return false;
        }
    }
}