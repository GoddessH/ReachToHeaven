using UnityEngine;
using UnityEngine.Pool;

public class HitBoxProduct : DamageSource
{
    //
    private CircleCollider2D m_collider;

    private void Awake()
        => m_collider = GetComponent<CircleCollider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(m_targetTag.ToString()))
            DoDamage(collision);
    }

    public void SetHitBoxRadius(float radius)
        => m_collider.radius = radius;

}
