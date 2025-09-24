using System.Collections.Generic;
using UnityEngine;

public class UpgradeStatManager : MonoBehaviour
{
    //
    [SerializeField] private PlayerStatManager m_statManager;
    [SerializeField] private List<UpgradeStatPanel> m_upgradeStatPanels = new List<UpgradeStatPanel>();
    [SerializeField] private List<UpgradeStat> m_upgradeStats = new List<UpgradeStat>();

    private int[] m_index = new int[3];

    private void OnEnable()
    {
        Time.timeScale = 0;
        SetupIndexes();

        for(int i = 0; i < m_index.Length; ++i)
        {
            m_upgradeStatPanels[i].Init(m_upgradeStats[m_index[i]]);
            m_upgradeStatPanels[i].gameObject.SetActive(true);
        }
    }

    private void OnDisable()
        => Time.timeScale = 1;

    private void SetupIndexes()
    {
        m_index[0] = Random.Range(0, m_upgradeStats.Count);

        m_index[1] = Random.Range(0, m_upgradeStats.Count - 1);
        if (m_index[1] >= m_index[0]) ++m_index[1];

        m_index[2] = Random.Range(0, m_upgradeStats.Count - 2);
        if (m_index[2] >= Mathf.Min(m_index[0], m_index[1])) ++m_index[2];
        if (m_index[2] >= Mathf.Max(m_index[0], m_index[1])) ++m_index[2];
    }

    public void OnChooseStat(int index)
    {
        UpgradeStat upgradeStat = m_upgradeStats[m_index[index]];
        m_statManager.UpgradeStat(upgradeStat.UpgradeStatSystemData, upgradeStat.AdditionType);
        gameObject.SetActive(false);
    }
}
