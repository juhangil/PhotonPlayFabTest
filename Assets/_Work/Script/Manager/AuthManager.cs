using System;
using System.Collections;

using PlayFab;
using PlayFab.Internal;

using Photon.Pun;
using Photon.Realtime;

using PF;

public class AuthManager : SingletonMonoBehaviour<AuthManager>
{
    public bool IsPlayFabLogin => PlayFabSettings.staticPlayer.IsClientLoggedIn();
    public bool HasPhotonAuth => photonAuth != null;

    AuthenticationValues photonAuth = null;

    public void ProcessLogin(Action onError = null) => Coroutiner.Start(_LoginPhoton(onError));

    IEnumerator _LoginPhoton(Action onError)
    {
        var pfLogin = PFClient.DeviceIDLogin(null);
        yield return pfLogin;

        if (pfLogin.IsSucceed)
        {
            Logger.DataLog(pfLogin.result, "Login Succeed");

            var phToken = PFClient.RequestPhotonToken();
            yield return phToken;

            if (phToken.IsSucceed)
            {
                photonAuth = new AuthenticationValues { AuthType = CustomAuthenticationType.Custom };

                photonAuth.AddAuthParameter("username", PlayFabSettings.staticPlayer.PlayFabId);
                photonAuth.AddAuthParameter("token", phToken.result.PhotonCustomAuthenticationToken);

                PhotonNetwork.AuthValues = photonAuth;

                Logger.DataLog(photonAuth, "Photon Auth");
            }
        }

        onError?.Invoke();
    }
}