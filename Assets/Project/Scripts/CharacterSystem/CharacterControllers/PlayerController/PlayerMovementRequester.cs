using UnityEngine;

[RequireComponent(typeof(InputController), typeof(CharacterStatManager))]
public class PlayerMovementRequester : CharacterMovementRequester
{
    //
    private CharacterStatManager m_playerStatsManager;

    private InputController m_inputController;

    protected override void Start()
    {
        base.Start();
        m_playerStatsManager = GetComponent<CharacterStatManager>();
        m_inputController = GetComponent<InputController>();
    }

    private void LateUpdate()
    {
        if (m_inputController.IsMoveActionPressing()) RequestState();
        else if (!m_isComplete)
        {
            m_nextStateChecker.ResetState();
            m_isComplete = true;
        }
    }

    #region Override CharacterMovementSensor
    public override void SetupDynamicContext()
    {
        m_requestData.Context.MovementSpeed = m_playerStatsManager.StatDictionary[StatType.MovementSpeed];

        m_requestData.Context.TargetPosition =
            (Vector2)gameObject.transform.position + m_inputController.GetMoveInput().normalized;
    }
    #endregion
}
