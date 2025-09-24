using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ExpBarUI
{
    //
    [SerializeField] private Image m_progressFill;
    [SerializeField] private TextMeshProUGUI m_levelLabel;
    private const string m_levelText = "Lv.";

    public void UpdateUI(float fillAmount)
        => m_progressFill.fillAmount = fillAmount;

    public void UpdateUI(float fillAmount, int currentLevel)
    {
        UpdateUI(fillAmount);
        m_levelLabel.text = m_levelText + currentLevel;
    }
}
