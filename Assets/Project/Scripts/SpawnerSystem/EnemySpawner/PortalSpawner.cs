using UnityEngine;
using System.Collections;

public class PortalSpawner : Spawner
{
    //
    [SerializeField] private Rigidbody2D m_playerRigidbody;
    [SerializeField] private Transform m_enemyField;
    [SerializeField] private int m_totalPortal;

    #region Supporter
    [SerializeField] private IntervalRandomizer m_intervalRandomizer = new IntervalRandomizer();
    [SerializeField] private PositionRandomizer m_positionRandomizer = new PositionRandomizer();
    #endregion

    private int m_portalCount;

    [SerializeField] private EnemyCounter m_enemyCounter;

    private void Start()
    {
        m_portalCount = 0;
        m_positionRandomizer.Init(m_playerRigidbody.transform);
        m_onExtraSetup = SetupPortalProduct;
        SetupProductPools();
        StartCoroutine(SpawnRoutine(5));
    }
    private void SetupPortalProduct(IProduct product)
    {
        PortalProduct portalProduct = ProductConverter.IProductToAnyType<PortalProduct>(product);
        portalProduct.Init(m_playerRigidbody, m_enemyField, m_enemyCounter.CountEnemy);
    }

    private IEnumerator SpawnRoutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        while(m_portalCount < m_totalPortal)
        {
            PortalProduct product = Spawn<PortalProduct>(0);
            product.gameObject.transform.position = m_positionRandomizer.RandomizePosition();
            ++m_portalCount;
            yield return new WaitForSeconds(m_intervalRandomizer.RandomizeInterval());
        }
    }
}
