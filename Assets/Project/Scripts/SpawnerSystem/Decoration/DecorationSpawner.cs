using UnityEngine;

public class DecorationSpawner : Spawner
{
    //
    [SerializeField] private int m_totalCount;
    [SerializeField] private PositionRandomizer m_positionRandomizer = new PositionRandomizer();
    [SerializeField] private IndexRandomizer m_indexRandomizer = new IndexRandomizer();

    private void Awake()
    {
        SetupProductPools();
        m_indexRandomizer.Init(m_productPrefabs.Count);
    }

    private void Start()
    {
        for(int i = 0; i < m_totalCount; ++i)
        {
            DecorationProduct product = Spawn<DecorationProduct>(m_indexRandomizer.GetRandomIndex());
            product.transform.position = m_positionRandomizer.RandomizePosition();
        }
    }
}
