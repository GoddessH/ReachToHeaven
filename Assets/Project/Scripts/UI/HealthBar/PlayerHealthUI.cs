using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : CharacterHealthUI
{
    //
    [SerializeField] private Image m_trailFill;
    [SerializeField] private float m_effectDuration;
    [SerializeField] private float m_interval;
    private float m_cachedHealthScale = 1;

    protected override void Start()
    {
        base.Start();
        m_trailFill.fillAmount = 1;
    }

    public override void UpdateHPUI(float maxHealth, float currentHealth)
    {
        float healthScale = currentHealth / maxHealth;
        if (healthScale > m_cachedHealthScale) RegenerateUI(healthScale);
        else if (healthScale < m_cachedHealthScale) DrainHealthUI(healthScale);

        m_cachedHealthScale = healthScale;
    }

    private void DrainHealthUI(float healthScale)
    {
        Sequence drainEffect = DOTween.Sequence();
        drainEffect.Append(m_healthFill.DOFillAmount(healthScale, m_effectDuration));
        drainEffect.AppendInterval(m_interval);
        drainEffect.Append(m_trailFill.DOFillAmount(healthScale, m_effectDuration));
        drainEffect.Play();
    }
    private void RegenerateUI(float healthScale)
    {
        Sequence regenerateEffect = DOTween.Sequence();
        regenerateEffect.Append(m_trailFill.DOFillAmount(healthScale, m_effectDuration));
        regenerateEffect.AppendInterval(m_interval);
        regenerateEffect.Append(m_healthFill.DOFillAmount(healthScale, m_effectDuration));
        regenerateEffect.Play();
    }
}
