using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class GemProduct : MonoBehaviour, IProduct
{
    //
    [SerializeField] private int m_expAmount;
    [SerializeField] private float m_absorbDistance;
    [SerializeField] private float m_absorbSpeed;
    private ObjectPool<IProduct> m_pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Absorber"))
        {
            StartCoroutine(AbsorbRoutine(collision.GetComponent<GemAbsorber>()));
        }
    }

    private IEnumerator AbsorbRoutine(GemAbsorber gemAbsorber)
    {
        while(Vector2.Distance(gameObject.transform.position, gemAbsorber.transform.position) > m_absorbDistance)
        {
            gameObject.transform.position =
                Vector2.MoveTowards(gameObject.transform.position, gemAbsorber.transform.position, m_absorbSpeed);
            yield return null;
        }
        gemAbsorber.AbsorbGem(m_expAmount);
        m_pool.Release(this);
    }


    #region Implement IProduct
    public ObjectPool<IProduct> GetPool()
        => m_pool;
    public void SetPool(ObjectPool<IProduct> pool)
        => m_pool = pool;
    #endregion
}
