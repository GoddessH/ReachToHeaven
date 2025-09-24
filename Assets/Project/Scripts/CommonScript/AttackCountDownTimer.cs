using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

[Serializable]
public class AttackCountDownTimer
{
    //
    private bool m_readyToAttack = true;

    public bool IsReadyToAttack() => m_readyToAttack;

    public void StartCountDown(MonoBehaviour monoBehaviour, float countDownTime)
        => monoBehaviour.StartCoroutine(CountDownRoutine(countDownTime));

    private IEnumerator CountDownRoutine(float countDownTime)
    {
        m_readyToAttack = false;
        yield return new WaitForSeconds(countDownTime);
        m_readyToAttack = true;
    }
}
