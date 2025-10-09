using UnityEngine;
using System.Collections;
public class PlayerHP : CharacterHP
{
    //
    [SerializeField] private float m_regenateInterval;

    protected override void Start()
    {
        base.Start();
        if (m_characterStatsManager is PlayerStatManager playerStatManager)
            playerStatManager.Subscribe(StatType.Health, UpdateMaxHealth);

        StartCoroutine(Regenerate());
    }

    public override void GetDamages(float amount)
    {
        //float damages = ReduceDamage(amount, m_characterStatsManager.StatDictionary[StatType.DamageReduction]);

        base.GetDamages(amount);

        if (amount >= m_currentHP)
        {
            SingletonUIManager.Instance.GameOverPanel.Active();
        }
    }

    private float ReduceDamage(float amount, float reduceAmount)
    {
        amount -= (reduceAmount * amount);
        if (amount < 0) amount = 0;

        return amount;
    }

    private void UpdateMaxHealth()
    {
        m_maxHP = m_characterStatsManager.StatDictionary[StatType.Health];
        m_healthUI.UpdateHPUI(m_maxHP, m_currentHP);
    }

    private IEnumerator Regenerate()
    {
        while (true)
        {
            if (m_currentHP < m_maxHP)
            {
                m_currentHP =
                    Mathf.Clamp(m_currentHP += m_characterStatsManager.StatDictionary[StatType.Regeneration], 0, m_maxHP);
                m_healthUI.UpdateHPUI(m_maxHP, m_currentHP);
                //Debug.Log("Regen");
                yield return new WaitForSeconds(m_regenateInterval);
            }

            yield return null;
        }
    }
}
