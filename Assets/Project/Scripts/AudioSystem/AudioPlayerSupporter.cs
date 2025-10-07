using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class AudioPlayerSupporter
{
    //
    [SerializeField] private List<AudioClip> m_clips = new List<AudioClip>();

    private AudioSource m_audioSource;

    public void Init(AudioSource source)
        => m_audioSource = source;

    public void PlayOneShot(int clipIndex)
        => m_audioSource.PlayOneShot(m_clips[clipIndex]);

    public void Play(int clipIndex)
    {
        m_audioSource.clip = m_clips[clipIndex];
        m_audioSource.Play();
    }
}
