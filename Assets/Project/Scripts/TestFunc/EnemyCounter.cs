using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    //
    private TextMeshProUGUI m_textMesh;
    private int m_count = 0;

    private void Awake()
    {
        m_textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void CountEnemy()
    {
        ++m_count;
        m_textMesh.text = m_count + "";
    }
}
