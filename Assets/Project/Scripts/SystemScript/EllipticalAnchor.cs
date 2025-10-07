using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EllipticalAnchor : MonoBehaviour
{
    //
    [SerializeField] private List<GameObject> m_followers = new List<GameObject>();
    [SerializeField] private EnemyProduct m_enemyProduct;
    [SerializeField] private float m_delayTime;

    [SerializeField] private EllipticCoordinateNormalizer m_normalizer = new EllipticCoordinateNormalizer();
    #region Test
    [SerializeField] private GameObject m_dummy;
    [SerializeField] private bool m_isShowBound;
    #endregion

    private void Start()
    {
        InvokeRepeating("UpdateFollowerPosition", 0, m_delayTime);
    }

    public void UpdateFollowerPosition()
    {
        Vector2 target;
        
        if (Application.isPlaying) target = m_enemyProduct.PlayerRigidbody.position;
        else
        {
            if (m_dummy != null) target = m_dummy.transform.position;
            else target = gameObject.transform.position;
        }

        Vector2 normalizedPosition = m_normalizer.ConvertToEllipticCoordinate(target, gameObject.transform.position);

        foreach (var follower in m_followers) follower.gameObject.transform.position = normalizedPosition;
    }

    [ExecuteInEditMode]
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;

        if (m_isShowBound)
        {
            Gizmos.DrawRay(gameObject.transform.position, Vector2.right * m_normalizer.WidthAxis);
            Gizmos.DrawRay(gameObject.transform.position, Vector2.up * m_normalizer.HeightAxis);
        }
    }
}
