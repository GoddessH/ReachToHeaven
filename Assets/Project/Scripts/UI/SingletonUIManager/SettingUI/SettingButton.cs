using UnityEngine;

public class SettingButton : MonoBehaviour
{
    //
    public void Execute()
        => SingletonUIManager.Instance.SettingPanel.ActivePanel();
}
