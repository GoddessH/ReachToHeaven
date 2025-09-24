using System.Collections.Generic;
using System;
using UnityEngine;

[Tooltip("Collect all activeable component used for deactive in DeathState")]
[Serializable]
public class ComponentCollector
{
    //
    [SerializeField] private List<Behaviour> m_components = new List<Behaviour>();

    public void ActiveAllComponents()
    {
        foreach(Behaviour component in m_components) component.enabled = true;
    }

    public void DeactiveAllComponents()
    {
        foreach (Behaviour component in m_components) component.enabled = false;
    }
}
