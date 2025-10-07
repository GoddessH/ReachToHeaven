using System;
using UnityEngine;

[Serializable]
public class CountRandomizer
{
    //
    [SerializeField] private Range m_countRange;

    public int RandomizeCount()
        => UnityEngine.Random.Range((int)m_countRange.Min, (int)m_countRange.Max + 1);
}
