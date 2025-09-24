using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class DamageSourceLifeController: ISubject<Action<IProduct>>
{
    //
    [SerializeField] private float m_lifeTime;
    private Action<IProduct> m_onEndLife;

    public void StartLifeTime(MonoBehaviour monoBehaviour, IProduct product)
    {
        monoBehaviour.StartCoroutine(LifeTimeRoutine(product));
    }
    private IEnumerator LifeTimeRoutine(IProduct product)
    {
        yield return new WaitForSeconds(m_lifeTime);
        m_onEndLife?.Invoke(product);
    }

    #region Implement ISUbject
    public void Subscribe(Action<IProduct> subscriber)
    {
        m_onEndLife += subscriber;
    }

    public void UnSubscribe(Action<IProduct> subscriber)
    {
        m_onEndLife -= subscriber;
    }    
    #endregion
}
