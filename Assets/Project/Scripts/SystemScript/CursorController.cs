using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    //
    [SerializeField] private InputAction m_clickAction;
    [SerializeField] private AudioClip m_onClickSFX;

    public static bool CanPlaySFX { get; set; }
    public bool m_hideDefaultCursor;

    private void Start()
    {
        if (m_hideDefaultCursor) Cursor.visible = false;

        m_clickAction.Enable();
        m_clickAction.performed += OnCursorClick;

        CanPlaySFX = true;
    }

    private void Update()
        => gameObject.transform.position = Mouse.current.position.ReadValue();

    private void OnCursorClick(InputAction.CallbackContext context)
    {
        if (CanPlaySFX) EventAudioManager.Instance.PlayEventSFX(m_onClickSFX);
    }
}
