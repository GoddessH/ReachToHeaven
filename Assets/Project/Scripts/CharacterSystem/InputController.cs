using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour, ISubject<Action<InputAction.CallbackContext>>
{
    //
    [SerializeField] private InputAction m_moveAction;
    [SerializeField] private InputAction m_attackAction;
    [SerializeField] private InputAction m_switchWeaponAction;

    public InputAction SwitchWeaponAction { get => m_switchWeaponAction; }


    private void Start()
    {
        m_moveAction.Enable();
        m_attackAction.Enable();
        m_switchWeaponAction.Enable();

        SingletonUIManager.Instance.SettingPanel.SetInputEvent(EnableInput, DisableInput);
    }

    public void EnableCursorClick()
        => m_attackAction.Enable();

    public void DisableCursorClick()
        => m_attackAction.Disable();

    public void EnableInput()
    {
        m_moveAction.Enable();
        m_attackAction.Enable();
        m_switchWeaponAction.Enable();
    }

    public void DisableInput()
    {
        m_moveAction.Disable();
        m_attackAction.Disable();
        m_switchWeaponAction.Disable();
    }


    #region Implement ISubject
    public void Subscribe(Action<InputAction.CallbackContext> subscriber)
    {
        m_attackAction.started += subscriber;
    }

    public void UnSubscribe(Action<InputAction.CallbackContext> subscriber)
    {
        m_attackAction.started -= subscriber;
    }
    #endregion

    #region Movement
    public bool IsMoveActionPressing()
    {
        return m_moveAction.IsPressed();
    }

    ///<summary>
    ///Return input value from moveAction
    ///</summary>
    public Vector2 GetMoveInput()
    {
        return m_moveAction.ReadValue<Vector2>();
    }
    #endregion
}
