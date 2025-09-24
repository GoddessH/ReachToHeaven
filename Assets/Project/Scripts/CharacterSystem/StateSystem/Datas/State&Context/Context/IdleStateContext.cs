using UnityEngine;

public class IdleStateContext : StateContext
{
    //
    public IdleStateContext(AnimatorController animatorController)
    {
        CharacterAnimatorController = animatorController;
    }
}
