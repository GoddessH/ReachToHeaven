using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileProduct : DamageSource
{
    //
    [SerializeField] private float m_baseDamages;

    private Rigidbody2D m_projectileRigid;
    public Rigidbody2D ProjectileRigid { get => m_projectileRigid; }

    public void SetData(HitBoxData data)
    {
        m_extraDamages = data.Damages;
        m_piercing = data.Piercing;
    }

    private void Awake()
    {
        m_projectileRigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(m_targetTag.ToString()))
        {
            DoDamage(collision);

            --m_piercing;
            if (m_piercing <= 0) m_pool.Release(this);
        }
    }

    protected override void DoDamage(Collider2D targetCollider)
    {
        float totalDamages = m_baseDamages + m_extraDamages;
        targetCollider.GetComponent<BodyPart>().CharacterHP.GetDamages(totalDamages); 
    }
}
