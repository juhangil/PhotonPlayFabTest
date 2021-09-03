using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayFab.SharedModels;

public class WaitForPF<T> : CustomYieldInstruction where T : PlayFabResultCommon
{
    public override bool keepWaiting => throw new System.NotImplementedException();

    
}