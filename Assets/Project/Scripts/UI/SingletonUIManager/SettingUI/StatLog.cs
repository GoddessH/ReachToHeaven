using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatLog : MonoBehaviour
{
    // 
    [SerializeField] private PlayerStatManager m_playerStatManager;
    [SerializeField] private List<Sprite> m_statSprites = new List<Sprite>();
    [SerializeField] private List<StatLogData> m_statLogDatas = new List<StatLogData>();

    private Dictionary<StatType, StatLogData> m_statDictionary = new Dictionary<StatType, StatLogData>();

    private void Start()
    {
        List<KeyValuePair<StatType, float>> statList 
            = m_playerStatManager.StatDictionary.ToList<KeyValuePair<StatType, float>>();

        for(int i = 0; i < m_statLogDatas.Count; ++i)
        {
            m_statDictionary[statList[i].Key] = m_statLogDatas[i];
            m_statDictionary[statList[i].Key].InitData(m_statSprites[i], statList[i].Value);
        }
    }

    private void OnEnable()
        => m_playerStatManager.Subscribe(UpdateStat);

    private void OnDisable()
        => m_playerStatManager.UnSubscribe(UpdateStat);

    private void UpdateStat(StatType type, float value)
        => m_statDictionary[type].UpdateValue(value);

}
