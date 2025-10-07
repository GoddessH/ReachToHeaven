using UnityEngine;

[RequireComponent(typeof(CharacterHP), typeof(CharacterController))]
public class CharacterHurtRequester : MonoBehaviour, IStateRequester
{
    //
    [SerializeField] private float m_invinsibleTime;
    [SerializeField] private AudioClip m_hurtSFX;
    [SerializeField] private AudioClip m_deathSFX;
 
    private NextStateChecker m_stateChecker;
    private CharacterHP m_characterHP;
    private bool m_isDeath = false;

    private RequestStateData<HurtStateContext> m_requestHurtData = 
        new RequestStateData<HurtStateContext>(StateType.HurtState);
    private RequestStateData<DeathStateContext> m_requestDeathData =
        new RequestStateData<DeathStateContext>(StateType.DeathState);

    [SerializeField] private ComponentCollector m_componentCollector = new ComponentCollector();

    private void Awake()
    {
        m_characterHP = GetComponent<CharacterHP>();
    }

    private void Start()
    {
        m_stateChecker = GetComponent<CharacterController>().StateMachine.StateChecker;
        SetupStaticContext();

        m_characterHP.Subscribe(RequestState);
        m_characterHP.OnDeath += () => m_isDeath = true;
        m_characterHP.OnDeath += () => GemManager.Instance.WrappedSpawn(gameObject.transform.position);
    }

    private void OnEnable()
        => m_isDeath = false;

    #region implement istaterequester
    public void RequestState()
    {
        SetupDynamicContext();

        if (m_isDeath) m_stateChecker.RequestHandle(m_requestDeathData);
        else m_stateChecker.RequestHandle(m_requestHurtData);
    }
    public void SetupStaticContext()
    {
        AnimatorController animController = GetComponent<AnimatorController>();

        m_requestHurtData.Context = new HurtStateContext();
        m_requestHurtData.Context.CharacterAnimatorController = animController;
        m_requestHurtData.Context.RoutineCaller = this;

        if(m_hurtSFX != null) 
            m_requestHurtData.Context.EnterEvent = () => EventAudioManager.Instance.PlayEventSFX(m_hurtSFX);

        m_requestHurtData.Context.CompleteEvent = m_stateChecker.ResetState;

        m_requestDeathData.Context = new DeathStateContext();
        m_requestDeathData.Context.CharacterAnimatorController = animController;
        m_requestDeathData.Context.RoutineCaller = this;

        m_requestDeathData.Context.EnterEvent += m_componentCollector.DeactiveAllComponents;
        if (m_deathSFX != null)
            m_requestDeathData.Context.EnterEvent += () => EventAudioManager.Instance.PlayEventSFX(m_deathSFX);
        m_requestDeathData.Context.CompleteEvent += m_stateChecker.ResetState;
        m_requestDeathData.Context.DecayEvent += m_componentCollector.ActiveAllComponents;
        m_requestDeathData.Context.DecayEvent += () => gameObject.SetActive(false);
    }
    public void SetupDynamicContext()
    {
        
    }
    #endregion
}
