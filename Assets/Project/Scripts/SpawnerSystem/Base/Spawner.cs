using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;
using System;

///<summary>
///Concrete Spawne must call SetupProductPools()
/// </summary>
public abstract class Spawner : MonoBehaviour
{
    //
    [Tooltip("Is maximum amount of product pool can store")]
    [SerializeField] protected int m_capacity;
    [Tooltip("Is the maximum amount of product can spawn")]
    [SerializeField] protected int m_maxSize;
    [Tooltip("Is the parent's transform of product")]
    [SerializeField] protected Transform m_productField;

    [SerializeField] protected List<MonoBehaviour> m_productPrefabs = new List<MonoBehaviour>();
    
    protected ObjectPool<IProduct>[] m_productPools;
    protected Action<IProduct> m_onExtraSetup;

    protected int m_poolIndex = 0;

    protected virtual void SetupProductPools()
    {
        m_productPools = new ObjectPool<IProduct>[m_productPrefabs.Count];

        SetDefault();

        m_poolIndex = 0;
        for(int i = 0; i < m_productPools.Length; ++i)
        {
            if (m_productPrefabs[i] is IProduct)
            {
                m_poolIndex = i;
                m_productPools[m_poolIndex] = new ObjectPool<IProduct>(
                    CreateProduct, OnGetProduct, OnReleaseProduct, OnDestroyProduct, true, m_capacity, m_maxSize);
            }
            else
            {
                Debug.LogWarning($"{this}: A prefab doesn't implement IProduct {m_productPrefabs[m_poolIndex]}");
                return;
            }
        }
    }

    ///<summary>
    ///Safe to call in Awake if don't have extra setup
    /// </summary>
    protected virtual IProduct CreateProduct()
    {
        MonoBehaviour objectProduct = Instantiate(m_productPrefabs[m_poolIndex], m_productField);
        IProduct product = ProductConverter.MonoToIProduct(objectProduct);
        m_onExtraSetup?.Invoke(product);
        product.SetPool(m_productPools[m_poolIndex]);

        return product;
    }

    ///<summary>
    ///Active product
    /// </summary>
    protected virtual void OnGetProduct(IProduct product)
        => ProductConverter.IProductToMono(product).gameObject.SetActive(true);

    ///<summary>
    ///Deactive product
    /// </summary>
    protected virtual void OnReleaseProduct(IProduct product)
        => ProductConverter.IProductToMono(product).gameObject.SetActive(false);

    ///<summary>
    ///Destroy product
    ///</summary>
    protected virtual void OnDestroyProduct(IProduct product)
        => Destroy(ProductConverter.IProductToMono(product));

    public virtual T Spawn<T>(int index) where T : class
    {
        m_poolIndex = index;
        return ProductConverter.IProductToAnyType<T>(m_productPools[m_poolIndex].Get());
    }

    ///<summary>
    ///Sets default productField, capacity, maxSize if unassigned
    /// </summary>
    protected virtual void SetDefault()
    {
        if (m_productField == null) m_productField = gameObject.transform;
        if (m_capacity == 0) m_capacity = 10;
        if (m_maxSize == 0) m_maxSize = 100000;
    }

    public int GetListCount()
        => m_productPrefabs.Count;
}
