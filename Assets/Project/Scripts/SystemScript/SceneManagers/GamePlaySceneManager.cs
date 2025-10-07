using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class GamePlaySceneManager : Singleton<GamePlaySceneManager>
{
    //
    [SerializeField] private AudioClip m_ambientAudio;
    [SerializeField] private AudioClip m_introAudio;

    private void Start()
    {
        AmbientAudioManager.Instance.PlayAmbientAudio(m_ambientAudio);
        EventAudioManager.Instance.PlayEventSFX(m_introAudio);

        CursorController.CanPlaySFX = false;
        SingletonUIManager.Instance.SettingPanel.SetSceneLayout(null, false, true);
    }
}
