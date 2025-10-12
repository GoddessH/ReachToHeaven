using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatLogData: MonoBehaviour
{
    //
    [SerializeField] private Image m_statLogImage;
    [SerializeField] private TextMeshProUGUI m_tmPro;

    public void InitData(Sprite sprite, float value)
    {
        m_statLogImage.sprite = sprite;
        m_tmPro.text = value.ToString();
    }

    public void UpdateValue(float value)
        => m_tmPro.text = value.ToString();
}
