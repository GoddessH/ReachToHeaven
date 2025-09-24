using System;
using UnityEngine;
using UnityEngine.Pool;

public class PortalProduct : MonoBehaviour, IProduct
{
    //
    private ObjectPool<IProduct> m_pool;

    public Transform EnemyField { get; private set; }
    public Rigidbody2D PlayerRigidbody { get; private set; }


    public Action OnCount;

    public void Init(Rigidbody2D playerRigidbody, Transform enemyProductField, Action onCount)
    {
        PlayerRigidbody = playerRigidbody;
        EnemyField = enemyProductField;
        OnCount = onCount;
    }

    #region Implement IProduct
    public void SetPool(ObjectPool<IProduct> pool)
        => m_pool = pool;
    public ObjectPool<IProduct> GetPool()
        => m_pool;
    #endregion
}
