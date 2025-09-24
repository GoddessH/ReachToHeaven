using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AnimatorController))]
public abstract class CharacterMovementRequester : MonoBehaviour, IStateRequester
{
    //
    protected NextStateChecker m_nextStateChecker;

    protected RequestStateData<MoveStateContext> m_requestData = new RequestStateData<MoveStateContext>(StateType.MoveState);

    ///<summary>
    ///Note: Must be assigned true value in concreteClass
    /// </summary>
    protected bool m_isComplete;

    ///<summary>
    ///Get CharacterController's reference
    /// </summary>
    protected virtual void Awake()
    {
        m_nextStateChecker = GetComponent<CharacterController>().StateMachine.StateChecker;
    }

    ///<summary>
    ///Call SetupStaticContext
    /// </summary>
    protected virtual void Start()
    {
        SetupStaticContext();
    }

    #region Implement IStateRequester
    ///<summary>
    ///Call SetupDynamicContext(), request state and assign m_isComplete false
    /// </summary>
    public void RequestState()
    {
        if (m_nextStateChecker == null)
        {
            Debug.LogWarning($"{this}: StateChecker is null -> {m_nextStateChecker}");
            return;
        }

        SetupDynamicContext();

        m_nextStateChecker.RequestHandle(m_requestData);
        m_isComplete = false;
    }

    ///<summary>
    ///Create new context; get AnimatorController's reference, Rigidbody2D's reference; subscribe CompleteEvent; 
    ///assign RoutineCaller
    /// </summary>
    public virtual void SetupStaticContext()
    {
        m_requestData.Context = 
            new MoveStateContext(GetComponent<AnimatorController>(), GetComponent<Rigidbody2D>());
        m_requestData.Context.CompleteEvent += m_nextStateChecker.ResetState;

        m_requestData.Context.RoutineCaller = this;
    }

    public abstract void SetupDynamicContext();
    #endregion

}
