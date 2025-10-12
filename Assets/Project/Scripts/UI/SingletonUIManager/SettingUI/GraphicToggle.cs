using UnityEngine;

public class GraphicToggle : ButtonToggle
{
    //
    [SerializeField] private GraphicTag m_graphicTag;

    protected override void Start()
    {
        base.Start();

        OnToggleOn += () => SingletonUIManager.Instance.SettingPanel.GraphicManager.ActiveGraphic(m_graphicTag, true);
        OnToggleOff += () => SingletonUIManager.Instance.SettingPanel.GraphicManager.ActiveGraphic(m_graphicTag, false);
    }

}
