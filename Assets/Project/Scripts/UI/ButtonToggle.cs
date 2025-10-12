using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonToggle : MonoBehaviour
{
    //
    [SerializeField] protected Sprite m_activeSprite, m_deactiveSprite;

    protected Image m_image;

    public event Action OnToggleOn, OnToggleOff;

    public bool IsActive { get; protected set; } = true;


    ///<summary>
    ///Get image component
    /// </summary>
    protected virtual void Awake()
        => m_image = GetComponent<Image>();

    ///<summary>
    ///Set isActive is true, image's sprite is activeSprite
    /// </summary>
    protected virtual void Start()
        => m_image.sprite = m_activeSprite;

    public void ResetAction()
    {
        OnToggleOn = null;
        OnToggleOff = null;
    }

    #region Call in ButtonEvent
    ///<summary>
    ///Switch activeState, change sprite, call back Actions
    /// </summary>
    public virtual void ChangeActiveState()
    {
        IsActive = !IsActive;
        if (IsActive)
        {
            m_image.sprite = m_activeSprite;
            if (OnToggleOn != null) OnToggleOn.Invoke();
            return;
        }

        m_image.sprite = m_deactiveSprite;
        if (OnToggleOff != null) OnToggleOff.Invoke();
    }
    #endregion
}
