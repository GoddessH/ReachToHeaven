using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterFoot : MonoBehaviour
{
    //
    public AudioSource AudioSource { get; private set; }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(bool playFlag)
    {
        if (playFlag) AudioSource.Play();
        else AudioSource.Stop();
    }

    public void ResetSource(AudioClip originalSFX)
    {
        AudioSource.clip = originalSFX;
        AudioSource.pitch = 1;
    }
}
