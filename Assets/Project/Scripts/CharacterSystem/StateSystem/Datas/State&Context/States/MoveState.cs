using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveState", menuName = "ScriptableObject/Character's States/MoveState")]
public class MoveState : StateLogic
{
    //
    public override void EnterState(StateContext context)
    {
        if (context is MoveStateContext moveContext)
        {
            if (moveContext.SpeedParameter != 0) 
                moveContext.CharacterAnimatorController.
                    CharacterAnimator.SetInteger("speedParameter", moveContext.SpeedParameter);

            moveContext.CharacterAnimatorController.CharacterAnimator.SetBool("isMove", true);

            moveContext.RoutineCaller.StartCoroutine(MoveRoutine(moveContext));
        }
        
    }

    public override void ExitState(StateContext context)
    {
        if (context is MoveStateContext moveContext)
        {
            moveContext.CharacterAnimatorController.CharacterAnimator.SetBool("isMove", false);
            moveContext.RoutineCaller.StopAllCoroutines();
        }
    }

    private IEnumerator MoveRoutine(MoveStateContext moveContext)
    {
        while(true)
        {
            moveContext.CharacterAnimatorController.
                UpdateDirection(moveContext.TargetPosition - moveContext.CharacterRigid.position);

            moveContext.CharacterRigid.MovePosition(
                Vector2.MoveTowards(moveContext.CharacterRigid.position,
                moveContext.TargetPosition,
                moveContext.MovementSpeed * Time.deltaTime));
            yield return null;
        }
        
    }
    
}
