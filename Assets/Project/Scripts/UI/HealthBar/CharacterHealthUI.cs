using UnityEngine;
using UnityEngine.UI;

///<summary>
///Has reference to Image healthFill, virtual Start and UpdateHPUI
/// </summary>
public class CharacterHealthUI : MonoBehaviour
{
    //
    [SerializeField] protected Image m_healthFill;

    ///<summary>
    ///Set healthFill's fill amount to 1
    /// </summary>
    protected virtual void Start()
    {
        m_healthFill.fillAmount = 1;
    }

    ///<summary>
    ///Update healthFill
    /// </summary>
    public virtual void UpdateHPUI(float maxHealth, float currentHealth)
    {
        m_healthFill.fillAmount = currentHealth / maxHealth;
    }
}
