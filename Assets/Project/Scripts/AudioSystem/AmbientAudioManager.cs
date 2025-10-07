using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AmbientAudioManager : Singleton<AmbientAudioManager>
{
    //
    [SerializeField] private AudioMixerGroup m_ambientGroup;
    private AudioSource m_audioSource;

    protected override void Awake()
    {
        m_isPersisted = true;
        m_audioSource = GetComponent<AudioSource>();

        base.Awake();
    }

    public void PlayAmbientAudio(AudioClip audioClip)
    {
        m_audioSource.clip = audioClip;
        m_audioSource.Play();
    }
}
