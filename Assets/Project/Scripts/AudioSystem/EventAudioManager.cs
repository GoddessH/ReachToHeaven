using UnityEngine;
using UnityEngine.Audio;

public class EventAudioManager : Singleton<EventAudioManager>
{
    //
    [SerializeField] private AudioMixerGroup m_eventGroup;
    private AudioSource m_audioSource;

    protected override void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.ignoreListenerPause = true;
        m_isPersisted = true;
        base.Awake();
    }

    public void PlayEventSFX(AudioClip eventClip)
        => m_audioSource.PlayOneShot(eventClip);
}
