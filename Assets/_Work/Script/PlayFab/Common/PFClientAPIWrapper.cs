using PlayFab;
using PlayFab.ClientModels;

namespace PF
{
    public static class PFClient
    {
        public static WaitForPF<GetPhotonAuthenticationTokenResult> RequestPhotonToken()
        {
            var request = new WaitForPF<GetPhotonAuthenticationTokenResult>();

            PlayFabClientAPI.GetPhotonAuthenticationToken(new GetPhotonAuthenticationTokenRequest
            {
                PhotonApplicationId = GlobalSettings.PhotonAppId
            },
                result => request.Sig(result),
                error => request.Sig(error)
            );

            return request;
        }

        public static WaitForPF<LoginResult> DeviceIDLogin(GetPlayerCombinedInfoRequestParams loginInfo)
        {
            var request = new WaitForPF<LoginResult>();

#if UNITY_EDITOR

            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
            {
                CreateAccount = true,
                CustomId = PlayFabSettings.DeviceUniqueIdentifier,
                InfoRequestParameters = loginInfo,
                TitleId = PlayFabSettings.TitleId
            },
                result => request.Sig(result),
                error => request.Sig(error)
            );

#elif !UNITY_EDITOR && UNITY_ANDROID

            PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest
            {
                CreateAccount = true,
                AndroidDevice = SystemInfo.deviceModel,
                OS = SystemInfo.operatingSystem,
                AndroidDeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                InfoRequestParameters = loginInfo,
                TitleId = PlayFabSettings.TitleId
            },
                result => request.Sig(result),
                error => request.Sig(error)
            );

#elif !UNITY_EDITOR && UNITY_IOS

            PlayFabClientAPI.LoginWithIOSDeviceID(new LoginWithIOSDeviceIDRequest
            {
                CreateAccount = true,
                DeviceModel = SystemInfo.deviceModel,
                OS = SystemInfo.operatingSystem,
                DeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                InfoRequestParameters = loginInfo,
                TitleId = PlayFabSettings.TitleId
            },
                result => request.Sig(result),
                error => request.Sig(error)
            );

#endif

            return request;
        }
    }
}