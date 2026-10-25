using HarmonyLib;
using Photon.Pun;
using PlayFab;
using GorillaNetworking;

namespace GTLegacy.Patches
{
    [HarmonyPatch(typeof(PlayFabAuthenticator), nameof(PlayFabAuthenticator.AuthenticateWithPlayFab))]
    class ServerInfo
    {
        static void Prefix()
        {
            PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime = "fdd3a39b-0376-4904-8c3e-db878d7c908f";
            PhotonNetwork.PhotonServerSettings.AppSettings.AppIdVoice = "7c868eda-6bea-47e4-8922-4c2dab1057e2";
            PlayFabSettings.TitleId = "19024B";
        }
    }
}
