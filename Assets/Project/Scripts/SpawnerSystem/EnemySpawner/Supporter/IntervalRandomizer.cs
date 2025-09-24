using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable] 
public class IntervalRandomizer
{
    //
    [SerializeField] private Range m_intervalRange = new Range();

    public float RandomizeInterval()
        => Random.Range(m_intervalRange.Min, m_intervalRange.Max);
}

[Serializable]
public struct Range
{
    public float Min, Max;
}
