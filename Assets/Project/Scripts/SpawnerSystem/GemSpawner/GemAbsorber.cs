using UnityEngine;

public class GemAbsorber : MonoBehaviour
{
    //
    [SerializeField] private PlayerStatManager m_statManager;
    [SerializeField] private ExpBarManager m_expBarManager;
    [SerializeField] private AudioClip m_coinCollectClip;
    private CircleCollider2D m_collider;

    private void Start()
    {
        m_collider = GetComponent<CircleCollider2D>();
        UpdateRadius();
        m_statManager.Subscribe(StatType.PickupRange, UpdateRadius);
    }

    public void UpdateRadius()
        => m_collider.radius = m_statManager.StatDictionary[StatType.PickupRange];


    public void AbsorbGem(int expAmount)
    {
        m_expBarManager.UpdateExpAmount(expAmount);
        EventAudioManager.Instance.PlayEventSFX(m_coinCollectClip);
    }

}
