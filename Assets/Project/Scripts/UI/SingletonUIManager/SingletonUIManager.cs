using UnityEngine;

public class SingletonUIManager : Singleton<SingletonUIManager>
{
    //
    [SerializeField] private SettingPanel m_settingPanel;
    [SerializeField] private CursorController m_cursorController;
    [SerializeField] private GameOverPanel m_gameOverPanel;

    public SettingPanel SettingPanel { get => m_settingPanel; }
    public CursorController CursorController { get => m_cursorController; }
    public GameOverPanel GameOverPanel { get => m_gameOverPanel; }

    protected override void Awake()
    {
        m_isPersisted = true;
        base.Awake();
    }
}
