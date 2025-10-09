using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class UpgradeStatPanel : MonoBehaviour
{
    //
    [SerializeField] private TextMeshProUGUI m_title;
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_description;
    private AudioClip m_flipCardSFX;

    private CanvasGroup m_canvasGroup;
    private CharacterStat m_statData;

    private void Awake()
        => m_canvasGroup = GetComponent<CanvasGroup>();

    private void OnEnable()
        => m_canvasGroup.alpha = .8f;

    public void Init(UpgradeStat data, AudioClip sfxClip)
    {
        m_title.text = data.UpgradeStatUIData.Title;
        m_icon.sprite = data.UpgradeStatUIData.Icon;
        m_description.text = data.UpgradeStatUIData.Description;
        m_statData = data.UpgradeStatSystemData;

        m_flipCardSFX = sfxClip;

        Debug.Log($"{m_statData.Type}");
    }

    #region Call in Button Event
    public void OnCursorEnter()
    {
        m_canvasGroup.alpha = 1;
        gameObject.transform.localScale = new Vector2(1.1f, 1.1f);

        EventAudioManager.Instance.PlayEventSFX(m_flipCardSFX);
    }

    public void OnCursorExit()
    {
        m_canvasGroup.alpha = .8f;
        gameObject.transform.localScale = Vector2.one;
    }
    #endregion
}
