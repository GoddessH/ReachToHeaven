using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackState", menuName = "ScriptableObject/Character's States/AttackState")]
public class AttackState : StateLogic
{
    // 
    public override void EnterState(StateContext context)
    {
        if (context is AttackStateContext attackContext)
        {
            attackContext.CharacterAnimatorController.CharacterAnimator.SetBool("isAttack", true);
            attackContext.CharacterAnimatorController.UpdateDirection(attackContext.Direction);

            if (context is PlayerAttackStateContext playerContext)
            {
                playerContext.CharacterAnimatorController.CharacterAnimator
                    .SetInteger("weaponIndex", playerContext.WeaponIndex);
            }

            attackContext.AttackRoutine = attackContext.RoutineCaller.StartCoroutine(CheckAnimationComplete(attackContext));
        }
    }

    public override void ExitState(StateContext context)
    {
        if (context is AttackStateContext attackContext)
        {
            attackContext.CharacterAnimatorController.CharacterAnimator.SetBool("isAttack", false);
            attackContext.RoutineCaller.StopCoroutine(attackContext.AttackRoutine);
        }
    }

    private IEnumerator CheckAnimationComplete(StateContext context)
    {
        yield return new WaitUntil(()
            => {
                AnimatorStateInfo stateInfo =
                context.CharacterAnimatorController.CharacterAnimator.GetCurrentAnimatorStateInfo(0);

                return stateInfo.IsTag("Attack") && stateInfo.normalizedTime >= 1;
            }
            );

        context.CompleteEvent?.Invoke();
    }
}
