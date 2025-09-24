using UnityEngine;

public abstract class StateLogic: ScriptableObject
{
    //
    public abstract void EnterState(StateContext context);
    public abstract void ExitState(StateContext context);
}
