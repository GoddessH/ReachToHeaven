using System;
using System.Collections.Generic;
using UnityEngine;

public class GraphicManager : MonoBehaviour
{
    //
    private Dictionary<GraphicTag, List<Action<bool>>> m_graphicDictionary = 
        new Dictionary<GraphicTag, List<Action<bool>>>();
    public Dictionary<GraphicTag, List<Action<bool>>> GraphicDictionary { get => m_graphicDictionary; }

    private Dictionary<GraphicTag, bool> m_activeStateDictionary = new Dictionary<GraphicTag, bool>();
    public Dictionary<GraphicTag, bool> ActiveStateDictionary { get => m_activeStateDictionary; }

    public void UpdateGraphic(Dictionary<GraphicTag, List<Action<bool>>> graphicDictionary)
        => m_graphicDictionary = graphicDictionary;

    public void ActiveGraphic(GraphicTag tag, bool state)
    {
        m_activeStateDictionary[tag] = state;

        if (!m_graphicDictionary.ContainsKey(tag)) return;

        foreach (var graphicAction in m_graphicDictionary[tag])
            graphicAction.Invoke(state);
    } 
}
