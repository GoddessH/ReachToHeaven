using UnityEngine;

[RequireComponent(typeof(GemSpawner))]
public class GemManager : Singleton<GemManager>
{
    //
    private Spawner m_gemSpawner;

    protected override void Awake()
    {
        base.Awake();

        m_gemSpawner = GetComponent<GemSpawner>();
    }

    public void WrappedSpawn(Vector2 position)
    {
        GemProduct product = m_gemSpawner.Spawn<GemProduct>(0);
        product.transform.position = position;
    }
}
