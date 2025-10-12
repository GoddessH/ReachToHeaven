using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class GamePlaySceneManager : SceneManager
{
    //
    [SerializeField] private AudioClip m_ambientAudio;
    [SerializeField] private AudioClip m_introAudio;
    [SerializeField] private StatLog m_statLog;

    protected override void Start()
    {
        base.Start();

        AmbientAudioManager.Instance.PlayAmbientAudio(m_ambientAudio);
        EventAudioManager.Instance.PlayEventSFX(m_introAudio);

        CursorController.CanPlaySFX = false;
        SingletonUIManager.Instance.SettingPanel.SetSceneLayout(null, false, true);

        m_statLog.gameObject.SetActive(SingletonUIManager.Instance.SettingPanel.StatLogToggle.IsActive);
        SingletonUIManager.Instance.SettingPanel.StatLogToggle.OnToggleOn += () => m_statLog.gameObject.SetActive(true);
        SingletonUIManager.Instance.SettingPanel.StatLogToggle.OnToggleOff += () => m_statLog.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        SingletonUIManager.Instance.SettingPanel.StatLogToggle.ResetAction();
    }
}
