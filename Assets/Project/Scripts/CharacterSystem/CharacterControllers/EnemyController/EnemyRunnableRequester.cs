using UnityEngine;

public class EnemyRunnableRequester : EnemyMovementRequester
{
    //
    [SerializeField] private CharacterHP m_characterHP;
    [SerializeField] private AudioClip m_walkSFX, m_runSFX;

    [SerializeField] private float m_runScale;
    [SerializeField] private float m_extraMovementSpeed;

    protected override void Start()
    {
        m_characterFoot.AudioSource.clip = m_walkSFX;
        base.Start();
    }

    public override void SetupStaticContext()
    {
        base.SetupStaticContext();

        m_requestData.Context.EnterEvent += () =>
        {
            if (m_requestData.Context.SpeedParameter == 2)
            {
                if (m_runSFX != null)
                {
                    m_characterFoot.AudioSource.clip = m_runSFX;
                    Debug.Log("Called");
                }
                else m_characterFoot.AudioSource.pitch = 2;
            }
        };

        m_requestData.Context.CompleteEvent += () => m_characterFoot.ResetSource(m_walkSFX);
        
    }

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
