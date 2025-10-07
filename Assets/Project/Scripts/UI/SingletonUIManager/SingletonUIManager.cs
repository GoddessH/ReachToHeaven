using UnityEngine;

public class SingletonUIManager : Singleton<SingletonUIManager>
{
    //
    [SerializeField] private SettingPanel m_settingPanel;
    [SerializeField] private CursorController m_cursorController;

    public SettingPanel SettingPanel { get => m_settingPanel; }
    public CursorController CursorController { get => m_cursorController; }

    protected override void Awake()
    {
        m_isPersisted = true;
        base.Awake();
    }
}
