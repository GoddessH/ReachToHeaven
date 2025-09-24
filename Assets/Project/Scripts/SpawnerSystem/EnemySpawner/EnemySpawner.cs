using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner
{
    //
    //[SerializeField] private int m_totalEnemy;
    [SerializeField] private float m_spawnInterval;

    private PortalProduct m_portalProduct;

    #region Supporter
    [SerializeField] private IntervalRandomizer m_intervalRandomizer = new IntervalRandomizer();
    private IndexRandomizer m_indexRandonmizer = new IndexRandomizer();
    #endregion

    private void Awake()
    {
        m_portalProduct = GetComponent<PortalProduct>();
    }

    private void Start()
    {
        m_productField = m_portalProduct.EnemyField;

        m_onExtraSetup = SetupEnemyProduct;
        SetupProductPools();

        m_indexRandonmizer.Init(m_productPrefabs.Count);
        StartCoroutine(SpawnEnemyRoutine(1));
    }

    private void SetupEnemyProduct(IProduct product)
        => ProductConverter.IProductToAnyType<EnemyProduct>(product).
        Init(m_portalProduct.PlayerRigidbody);

    private IEnumerator SpawnEnemyRoutine(int amount)
    {
        while (true)
        {
            yield return new WaitForSeconds(m_spawnInterval);
            Spawn<EnemyProduct>(m_indexRandonmizer.GetRandomIndex());
        }
    }

    #region Override Spawner
    protected override void OnGetProduct(IProduct product)
    {
        EnemyProduct enemyProduct = ProductConverter.IProductToAnyType<EnemyProduct>(product);
        enemyProduct.transform.position = gameObject.transform.position;

        base.OnGetProduct(product);
    }

    public override T Spawn<T>(int index)
    {
        m_portalProduct.OnCount?.Invoke();
        return base.Spawn<T>(index);
    }
    #endregion

}
