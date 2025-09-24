using UnityEngine;

public class EnemyAttackRequester : CharacterAttackRequester
{
    //
    [SerializeField] private EnemyAttackRange m_attackRange;
    [SerializeField] private HitBoxSpawner m_hitBoxSpawner;
    private EnemyProduct m_enemyProduct;

    private RequestStateData<AttackStateContext> m_requestData = 
        new RequestStateData<AttackStateContext>(StateType.AttackState);

    private AttackEventHandler m_eventHandle = new AttackEventHandler();

    private void Awake()
    {
        m_enemyProduct = GetComponent<EnemyProduct>();
    }

    protected override void Start()
    {
        base.Start();
        SetupStaticContext();

        m_attackRange.OnInRange += RequestState;
        m_attackRange.OnInRange += m_eventHandle.ResetAnimationTime;
        m_attackRange.OnOutRange += m_stateChecker.ResetState;

        m_eventHandle.OnEventCallBack += () => m_hitBoxSpawner.Spawn<HitBoxProduct>(0);
    }

    #region Call in AnimationEvent
    public void WrappedSpawnHitBox(float animationTime)
    {
        m_eventHandle.Spawn(animationTime);
    }
    #endregion

    #region Override CharacterAttackSensor
    public override void RequestState()
    {
        SetupDynamicContext();
        m_stateChecker.RequestHandle(m_requestData);
    }

    public override void SetupStaticContext()
    {
        m_requestData.Context = new AttackStateContext();
        SetupBasicStaticContext(m_requestData.Context);
    }

    public override void SetupDynamicContext()
    {
        m_requestData.Context.Direction = (m_enemyProduct.PlayerRigidbody.position - (Vector2)gameObject.transform.position).normalized;
    }
    #endregion
}
