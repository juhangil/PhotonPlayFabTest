using System.Collections;
using UnityEngine;

using PlayFab.Internal;

public class Coroutiner : SingletonMonoBehaviour<Coroutiner>
{
    public static Coroutine Start(IEnumerator routine) => Coroutiner.instance.StartCoroutine(routine);
    public static void Stop(Coroutine coroutine) => Coroutiner.instance.StopCoroutine(coroutine);
    public static void StopAll() => Coroutiner.instance.StopAllCoroutines();
}