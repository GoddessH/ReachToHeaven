using Unity.VisualScripting;
using UnityEngine;

public class EnemyRunnableRequester : EnemyMovementRequester
{
    //
    [SerializeField] private CharacterHP m_characterHP;
    [SerializeField] private float m_runScale;
    [SerializeField] private float m_extraMovementSpeed;

    public override void SetupDynamicContext()
    {
        m_requestData.Context.TargetPosition = m_enemyProduct.PlayerRigidbody.position;


        float movementSpeed = m_statManager.StatDictionary[StatType.MovementSpeed];

        if (m_characterHP.IsHPLowerThanScale(m_runScale))
        {
            m_requestData.Context.SpeedParameter = 2;
            m_requestData.Context.MovementSpeed = movementSpeed + m_extraMovementSpeed;
        }
        else
        {
            m_requestData.Context.SpeedParameter = 0;
            m_requestData.Context.MovementSpeed = movementSpeed;
        }
    }
}
