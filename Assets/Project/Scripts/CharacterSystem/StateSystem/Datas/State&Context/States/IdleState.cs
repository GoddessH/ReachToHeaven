using System.Net.Mime;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "ScriptableObject/Character's States/IdleState")]
public class IdleState : StateLogic
{
    //

    public override void EnterState(StateContext context)
    {
        if (context is IdleStateContext idleContext)
        {
            idleContext.CharacterAnimatorController.CharacterAnimator.SetBool("isIdle", true);
        }
    }

    public override void ExitState(StateContext context)
    {
        if (context is IdleStateContext idleContext)
        {
            idleContext.CharacterAnimatorController.CharacterAnimator.SetBool("isIdle", false);
        }
    }
}
