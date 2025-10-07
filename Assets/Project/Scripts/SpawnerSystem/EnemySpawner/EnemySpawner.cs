using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner
{
    //

    private PortalProduct m_portalProduct;
    private Animator m_animator;
    private int m_spawnCount;

    #region Supporter
    [SerializeField] private CountRandomizer m_countRandomizer = new CountRandomizer(); 
    [SerializeField] private IntervalRandomizer m_intervalRandomizer = new IntervalRandomizer();
    private IndexRandomizer m_indexRandonmizer = new IndexRandomizer();

    [SerializeField] private AudioPlayerSupporter m_audioPlayer = new AudioPlayerSupporter();
    #endregion

    private void Awake()
    {
        m_portalProduct = GetComponent<PortalProduct>();
        m_animator = GetComponent<Animator>();

        m_audioPlayer.Init(GetComponent<AudioSource>());
    }

    private void Start()
    {
        m_productField = m_portalProduct.EnemyField;

        m_onExtraSetup = SetupEnemyProduct;
        SetupProductPools();

        m_indexRandonmizer.Init(m_productPrefabs.Count);
        StartCoroutine(SpawnEnemyRoutine(1));
    }

    private void OnEnable()
    {
        m_spawnCount = 0;
        m_audioPlayer.PlayOneShot(0);
    }

    private void SetupEnemyProduct(IProduct product)
        => ProductConverter.IProductToAnyType<EnemyProduct>(product).Init(m_portalProduct.PlayerRigidbody);

    private IEnumerator SpawnEnemyRoutine(int amount)
    {
        m_audioPlayer.Play(1);
        while (m_spawnCount < m_countRandomizer.RandomizeCount())
        {
            yield return new WaitForSeconds(m_intervalRandomizer.RandomizeInterval());
            Spawn<EnemyProduct>(m_indexRandonmizer.GetRandomIndex());
            ++m_spawnCount;
        }

        m_animator.SetTrigger("isClose");
        m_audioPlayer.PlayOneShot(2);
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
