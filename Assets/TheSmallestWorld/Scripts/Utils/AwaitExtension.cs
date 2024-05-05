using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public static class AwaitExtension
{
    public static void ActionDelayed(this MonoBehaviour mono, float delay, UnityAction action)
    {
        mono.StartCoroutine(ExecuteAction(delay, action));
    }

    private static IEnumerator ExecuteAction(float delay, UnityAction action)
    {
        yield return new WaitForSecondsRealtime(delay);
        action?.Invoke();
        yield break;
    }
}
