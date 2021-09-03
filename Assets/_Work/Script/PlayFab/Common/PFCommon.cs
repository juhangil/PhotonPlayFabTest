using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayFab;
using PlayFab.SharedModels;

public static class PFCommon
{
    public static PlayFabError TimeOutError => new PlayFabError
    {
        ApiEndpoint = $"https://{PlayFabSettings.TitleId}.playfabapi.com/",
        HttpCode = 408,
        HttpStatus = "Request Time Out",
        ErrorMessage = "The server did not receive a complete request message within the time that it was prepared to wait.",
        Error = PlayFabErrorCode.ConnectionError
    };
}

public class WaitForPF<T> : CustomYieldInstruction where T : PlayFabResultCommon
{
    public override bool keepWaiting => !_hasRequest && CheckTimeOut();
    public bool IsSucceed => result != null;

    public T result;
    public PlayFabError error;
    bool _hasRequest = false;

    float _timeStamp;

    public WaitForPF()
    {
        _timeStamp = Time.time;
    }

    public void Sig(T result)
    {
        this.result = result;
        this.error = null;
        _hasRequest = true;
    }

    public void Sig(PlayFabError error)
    {
        this.result = null;
        this.error = error;
        _hasRequest = true;
    }

    bool CheckTimeOut()
    {
        if (Time.time - _timeStamp < GlobalSettings.PF_REQUEST_TIMEOUT)
        {
            Sig(PFCommon.TimeOutError);
            return false;
        }

        return true;
    }
}