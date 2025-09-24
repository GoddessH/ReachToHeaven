using UnityEngine;

public class IndexRandomizer
{
    //
    private int m_totalPrefab;
    public void Init(int totalPrefab)
    {
        m_totalPrefab = totalPrefab;
    }

    public int GetRandomIndex()
    {
        return Random.Range(0, m_totalPrefab);
    }
}
