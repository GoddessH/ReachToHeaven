using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher
{
    //
    private InputController m_inputController;
    private int m_weaponCount;
    public int WeaponIndex { get; private set; }

    public void Init(InputController inputController, int weaponPrefabCount)
    {
        WeaponIndex = 0;
        m_weaponCount = weaponPrefabCount;

        m_inputController = inputController;
        m_inputController.SwitchWeaponAction.started += SwitchWeaponIndex;
    }

    private void SwitchWeaponIndex(InputAction.CallbackContext context)
    {
        WeaponIndex = (int)Mathf.Repeat(++WeaponIndex, m_weaponCount);
    }
    
}
