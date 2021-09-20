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
    public bool HasPhotonAuth => _photonAuth != null;

    AuthenticationValues _photonAuth = null;

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
                _photonAuth = new AuthenticationValues { AuthType = CustomAuthenticationType.Custom };

                _photonAuth.AddAuthParameter("username", PlayFabSettings.staticPlayer.PlayFabId);
                _photonAuth.AddAuthParameter("token", phToken.result.PhotonCustomAuthenticationToken);

                PhotonNetwork.AuthValues = _photonAuth;

                Logger.DataLog(_photonAuth, "Photon Auth");
            }
        }

        onError?.Invoke();
    }
}