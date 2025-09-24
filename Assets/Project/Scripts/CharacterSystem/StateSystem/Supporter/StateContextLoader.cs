using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StateContextLoader
{
    //
    private StateContext m_stateContext;
    private StateType m_stateType;

    public void LoadContext(StateContext context, StateType type)
    {
        m_stateContext = context;
        m_stateType = type;
    }


    ///<param name="type">
    ///State must declare its own type to ensure context type-safety.
    /// </param>
    public StateContext GetContext(StateType type)
    {
        if (type != m_stateType)
        {
            Debug.LogWarning($"{this}: Currency context is {m_stateType} but {type} is trying to access");
        }
        return m_stateContext;
    }
}
