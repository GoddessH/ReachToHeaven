using UnityEngine;
using UnityEngine.Pool;

public class DecorationProduct : MonoBehaviour, IProduct
{
    //
    private ObjectPool<IProduct> m_pool;

    public ObjectPool<IProduct> GetPool()
        => m_pool;

    public void SetPool(ObjectPool<IProduct> pool)
        => m_pool = pool;
}
