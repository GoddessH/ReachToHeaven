using UnityEngine;

public class ActiveToggle : ButtonToggle
{
    // 
    [SerializeField] private GameObject m_targetGameObject;

    protected override void Start()
    {
        base.Start();
        OnToggleOn += () => m_targetGameObject.SetActive(true);
        OnToggleOff += () => m_targetGameObject.SetActive(false);
    }
}
