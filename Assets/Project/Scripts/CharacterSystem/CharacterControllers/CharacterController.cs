using UnityEngine;

[RequireComponent(typeof(CharacterAttackRequester), typeof(CharacterHurtSensor), typeof(CharacterMovementRequester))]
public class CharacterController : MonoBehaviour
{
    //
    [SerializeField] StateMachine m_stateMachine = new StateMachine();
    public StateMachine StateMachine { get => m_stateMachine; }

    private void Awake()
    {
        m_stateMachine.Init(gameObject.name, GetComponent<AnimatorController>());
    }
}
