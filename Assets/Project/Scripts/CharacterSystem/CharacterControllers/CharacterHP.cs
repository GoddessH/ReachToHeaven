using System;
using UnityEngine;

public class CharacterHP : MonoBehaviour, ISubject<Action>
{
    //
    [SerializeField] protected CharacterHealthUI m_healthUI;
    protected CharacterStatManager m_characterStatsManager;

    protected Action m_onGetDamages;
    protected float m_maxHP;
    protected float m_currentHP;

    public event Action OnDeath;

    protected virtual void Awake()
    {
        m_characterStatsManager = GetComponent<CharacterStatManager>();
    }

    protected virtual void Start()
    {
        m_maxHP = m_characterStatsManager.StatDictionary[StatType.Health];
        m_currentHP = m_maxHP;
    }

    public virtual void GetDamages(float amount)
    {
        if (amount < m_currentHP) m_currentHP -= amount;
        else
        {
            m_currentHP = 0;
            OnDeath?.Invoke();
        }

        m_healthUI.UpdateHPUI(m_maxHP, m_currentHP);
        m_onGetDamages?.Invoke();
    }

    ///<summary>
    ///Return true if scaleAmount lower or equal currentHP / maxHP
    /// </summary>
    public bool IsHPLowerThanScale(float scaleAmount)
        => scaleAmount <= (m_currentHP / m_maxHP);

    #region Implement ISubject
    public void Subscribe(Action subscriber)
    {
        m_onGetDamages += subscriber;
    }
    public void UnSubscribe(Action subscriber)
    {
        m_onGetDamages -= subscriber;
    }
    #endregion
}
