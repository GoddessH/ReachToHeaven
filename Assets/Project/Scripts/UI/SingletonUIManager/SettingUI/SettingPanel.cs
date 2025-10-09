using System;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    //
    [SerializeField] private GameObject m_homeButton;

    private GameObject m_previousPanel;
    private bool m_canCursorPlaySFX;
    private bool m_isHomeButtonAllowed;

    private Action m_onEnableInput;
    private Action m_onDisableInput;

    public void SetSceneLayout(GameObject previousPanel, bool canCursorPlaySFX, bool isHomeButtonAllowed)
    {
        m_previousPanel = previousPanel;
        m_canCursorPlaySFX = canCursorPlaySFX;
        m_isHomeButtonAllowed = isHomeButtonAllowed;
    }

    public void SetInputEvent(Action onEnable, Action onDisable)
    {
        m_onEnableInput = onEnable;
        m_onDisableInput = onDisable;
    }

    private void SetPermission()
    {
        CursorController.CanPlaySFX = true;
        m_homeButton.SetActive(m_isHomeButtonAllowed);
    }

    #region Call in ButtonEvent
    public void ActivePanel()
    {
        if (m_previousPanel != null) m_previousPanel.SetActive(false);
        if (m_onDisableInput != null) m_onDisableInput.Invoke();

        SetPermission();
        GameManager.FreezeScreen();
        gameObject.SetActive(true);
        //Debug.Log("EnterSettingPanel");
    }

    public void ExitSettingPanel()
    {
        if (m_previousPanel != null) m_previousPanel.SetActive(true);
        if (m_onEnableInput != null) m_onEnableInput.Invoke();

        if (!m_canCursorPlaySFX) CursorController.CanPlaySFX = false;
        GameManager.UnFreezeScreen();
        gameObject.SetActive(false);
        //Debug.Log("ExitSettingPanel");
    }
    #endregion
}
