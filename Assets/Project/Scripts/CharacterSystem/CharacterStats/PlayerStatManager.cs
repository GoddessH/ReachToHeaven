using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : CharacterStatManager, ISubject<Action<StatType, float>>
{
    //
    private Dictionary<StatType, float> m_finalStat = new Dictionary<StatType, float>();
    private Dictionary<StatType, float> m_bonusStat = new Dictionary<StatType, float>();
    private Dictionary<StatType, Action> m_updateUIDictionary = new Dictionary<StatType, Action>();

    private Action<StatType, float> m_onChangeValue;

    public override Dictionary<StatType, float> StatDictionary { get => m_finalStat; }

    protected override void Awake()
    {
        base.Awake();
        foreach (var stat in m_baseStats)
        {
            m_bonusStat[stat.Key] = 0;
            m_finalStat[stat.Key] = stat.Value;
        }
    }

    public void UpgradeStat(CharacterStat statData, AdditionType additionType)
    {
        m_bonusStat[statData.Type] += statData.Value;

        if (additionType == AdditionType.Flat)
            m_finalStat[statData.Type] = m_baseStats[statData.Type] + m_bonusStat[statData.Type];
        else m_finalStat[statData.Type]
               = m_baseStats[statData.Type] + m_baseStats[statData.Type] * m_bonusStat[statData.Type] / 100;

        if (m_updateUIDictionary.ContainsKey(statData.Type)) m_updateUIDictionary[statData.Type]?.Invoke();
        if (m_onChangeValue != null) m_onChangeValue.Invoke(statData.Type, m_finalStat[statData.Type]);

        Debug.Log(statData.Type + ": " + m_finalStat[statData.Type]);
    }

    public void Subscribe(StatType type, Action updateEvent)
    {
        if (m_updateUIDictionary.ContainsKey(type)) return;

        m_updateUIDictionary[type] = updateEvent;
    }

    #region Implement ISubject
    public void Subscribe(Action<StatType, float> subscriber)
        => m_onChangeValue = subscriber;
    public void UnSubscribe(Action<StatType, float> subscriber)
        => m_onChangeValue -= subscriber;
    #endregion
}
