using System;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour, ISubject<Action<float>>
{
    //
    [SerializeField] private Sprite m_unMuteSprite, m_muteSprite;
    private Image m_image;

    private Action<float> m_onMute;
    private bool m_isMute;

    public bool IsMute { get => m_isMute; }

    private void Awake()
        => m_image = GetComponent<Image>();

    private void Start()
    {
        m_isMute = false;
        m_image.sprite = m_unMuteSprite;
    }

    public void Mute()
    {
        m_isMute = true;
        m_image.sprite = m_muteSprite;
    }

    #region Call in ButtonEvent
    public void ChangeMute()
    {
        m_isMute = !m_isMute;
        if (m_isMute)
        {
            m_onMute.Invoke(0);
            m_image.sprite = m_muteSprite;
            return;
        }

        m_onMute.Invoke(1);
        m_image.sprite = m_unMuteSprite;
    }
    #endregion

    #region Implement ISubject
    public void Subscribe(Action<float> subscriber)
        => m_onMute = subscriber;
    public void UnSubscribe(Action<float> subscriber)
        => m_onMute -= subscriber;
    #endregion
}
