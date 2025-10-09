using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    //
    [SerializeField] private Slider m_audioSlider;
    [SerializeField] private AudioMixerGroup m_mixerGroup;
    [SerializeField] private MixerParameter m_parameterName;

    [SerializeField] private MuteButton m_muteButton;

    private void Start()
        => m_muteButton.Subscribe(SetVolume);

    private void SetVolume(float value)
    {
        OnChangeVolume(value);
        m_audioSlider.value = value;
    }


    #region Call in Button Event
    public void OnChangeVolume(float value)
    {
        if (value <= 0)
        {
            value = .00001f;
            m_muteButton.Mute();
        }
        else if (m_muteButton.IsMute) m_muteButton.ChangeMute();

        m_mixerGroup.audioMixer.SetFloat(m_parameterName.ToString(), Mathf.Log10(value) * 20);
    }
    #endregion
}

public enum MixerParameter
{
    MasterVolume, AmbientVolume, EventVolume
}