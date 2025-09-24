using UnityEngine;
using UnityEngine.Pool;

public interface IProduct
{
    //
    public void SetPool(ObjectPool<IProduct> pool);
    public ObjectPool<IProduct> GetPool();
}
