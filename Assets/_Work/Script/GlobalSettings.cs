using Photon.Pun;

public static class GlobalSettings
{
    public static readonly bool DEBUG_MODE = true;
    public static readonly float PF_REQUEST_TIMEOUT = 5f;
    public static string PhotonAppId => PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime;
}