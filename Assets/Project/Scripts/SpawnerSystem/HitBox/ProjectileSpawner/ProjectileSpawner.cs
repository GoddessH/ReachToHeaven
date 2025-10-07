using UnityEngine;

public class ProjectileSpawner : Spawner
{
    //
    [SerializeField] private float m_forceModifier;
    private HitBoxData m_data;
    private Vector2 m_addForceDirection;

    private void Awake()
        => SetupProductPools();

    protected override void OnGetProduct(IProduct product)
    {
        base.OnGetProduct(product);

        ProjectileProduct objectProduct = ProductConverter.IProductToAnyType<ProjectileProduct>(product);
        objectProduct.SetData(m_data);
        objectProduct.gameObject.transform.position = gameObject.transform.position;

        objectProduct.ProjectileRigid.
            SetRotation(Mathf.Atan2(m_addForceDirection.y, m_addForceDirection.x) * Mathf.Rad2Deg);

        objectProduct.ProjectileRigid.AddForce(m_addForceDirection.normalized * m_forceModifier, ForceMode2D.Impulse);
    }

    public void SetData(Vector2 direction, HitBoxData data)
    {
        m_addForceDirection = direction;
        m_data = data;
    }
}
