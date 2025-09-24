using System.Collections.Generic;
using UnityEngine;

public class EllipticalAnchor : MonoBehaviour
{
    //
    [SerializeField] private List<GameObject> m_followers = new List<GameObject>();
    [SerializeField] private EnemyProduct m_enemyProduct;
    [SerializeField] private float m_delayTime;


    [SerializeField] private EllipticCoordinateNormalizer m_normalizer = new EllipticCoordinateNormalizer();
    #region Test
    [SerializeField] private bool m_isShowBound;
    #endregion

    private void Start()
    {
        InvokeRepeating("UpdateFollowerPosition", 0, m_delayTime);
    }

    public void UpdateFollowerPosition()
    {
        Vector2 normalizedPosition = m_normalizer.ConvertToEllipticCoordinate(m_enemyProduct.PlayerRigidbody.position,
            gameObject.transform.position);

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
