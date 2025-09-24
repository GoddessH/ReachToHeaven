using System;
using UnityEngine;

//NextStateChecker is IdleRequester itself
public class NextStateChecker
{
    //
    private StateMachine m_owner;
    private string m_ownerName;

    private RequestStateData<IdleStateContext> m_requestData = new RequestStateData<IdleStateContext>(StateType.IdleState);
    ///<summary>
    ///Set owning StateMachine, initialize next state is IdleState and priority is 10
    /// </summary>
    public void Init(string ownerName, StateMachine owner, AnimatorController animatorController)
    {
        m_ownerName = ownerName;
        m_owner = owner;

        m_requestData.Context = new IdleStateContext(animatorController);
    }

    public void RequestHandle<TStateContext>(RequestStateData<TStateContext> nextStateData)
        where TStateContext : StateContext
    {
        if (m_owner.StateDict.ContainsKey(nextStateData.Type))
        {
            if (m_owner.StateDict[nextStateData.Type].Priority > m_owner.CurrentState.Priority)
            {
                m_owner.ChangeState(nextStateData);
                //Debug.Log($"{this} - {m_ownerName}: CurrentState -> {nextStateData.Type}");
            }
            //else Debug.Log($"{this}: {nextStateData.Type} is requesting but fail");
        }
        else
            Debug.LogWarning($"{m_owner}: StateMachine doesn't contains {nextStateData.Type.ToString()}" +
                " in CharacterState list");
    }

    public void ResetState()
    {
        //Debug.Log("Checker reset state");
        m_owner.ChangeState(m_requestData);
    }
    
}
