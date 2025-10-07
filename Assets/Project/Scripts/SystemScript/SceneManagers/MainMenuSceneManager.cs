using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class MainMenuSceneManager : Singleton<MainMenuSceneManager>
{
    //
    [SerializeField] private AudioClip m_ambientAudio;
    [SerializeField] private GameObject m_mainMenu;

    private void Start()
    {
        if (m_ambientAudio != null) AmbientAudioManager.Instance.PlayAmbientAudio(m_ambientAudio);
        CursorController.CanPlaySFX = true;
        SingletonUIManager.Instance.SettingPanel.SetSceneLayout(m_mainMenu, true, false);

        Debug.Log("StartMainMenu: " + CursorController.CanPlaySFX);
    }
}
