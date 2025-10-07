using System.Collections.Generic;
using UnityEngine;

public class SettingPanelManager : MonoBehaviour
{
    //
    [SerializeField] private List<GameObject> m_settingPanels = new List<GameObject>();

    private int m_previousEnabledPanel = 0;

    private void Start()
    {
        foreach (var field in m_settingPanels) field.SetActive(false);

        m_previousEnabledPanel = 0;
        m_settingPanels[m_previousEnabledPanel].SetActive(true);
    }

    public void EnablePanel(int index)
    {
        m_settingPanels[m_previousEnabledPanel].SetActive(false);
        m_settingPanels[index].SetActive(true);
        m_previousEnabledPanel = index;
    }
}
