using UnityEngine;
using UnityEngine.Pool;

public abstract class DamageSource : MonoBehaviour, IProduct
{
    //
    [SerializeField] protected TargetTag m_targetTag;
    protected ObjectPool<IProduct> m_pool;

    [SerializeField] protected DamageSourceLifeController m_lifeController = new DamageSourceLifeController();

    ///<summary>
    ///Is the damages get from character's stat
    /// </summary>
    protected float m_extraDamages;

    ///<summary>
    ///How many enemies can be pierced
    /// </summary>
    protected int m_piercing;

    ///<summary>
    ///Subscibe pool.Release() to lifeController.OnEndLife
    /// </summary>
    protected virtual void Start()
        => m_lifeController.Subscribe(m_pool.Release);

    protected virtual void OnEnable()
    {
        m_lifeController.StartLifeTime(this, this);
    }

    public virtual void SetExtraDamages(float extraDamages)
        => m_extraDamages = extraDamages;

    ///<summary>
    ///Call CharacterHP's GetDamages method of target with extraDamages
    /// </summary>
    protected virtual void DoDamage(Collider2D targetCollider)
        => targetCollider.GetComponent<BodyPart>().CharacterHP.GetDamages(m_extraDamages);

    #region Implement IProduct
    public void SetPool(ObjectPool<IProduct> pool) => m_pool = pool;
    public ObjectPool<IProduct> GetPool() => m_pool;
    #endregion
}
