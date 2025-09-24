using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DeathState", menuName = "ScriptableObject/Character's States/DeathState")]
public class DeathState : StateLogic
{
    //
    public override void EnterState(StateContext context)
    {
        context.CharacterAnimatorController.CharacterAnimator.SetBool("isDeath", true);
        context.EnterEvent?.Invoke();
        if (context is DeathStateContext deathContext)
            deathContext.RoutineCaller.
                StartCoroutine(
                DecayDelay(context.CharacterAnimatorController.CharacterAnimator, deathContext.CompleteEvent)
                );
    }

    public override void ExitState(StateContext context)
    {
        context.CharacterAnimatorController.CharacterAnimator.SetBool("isDeath", false);
        if (context is DeathStateContext deathContext) deathContext.DecayEvent?.Invoke();
    }

    private IEnumerator DecayDelay(Animator animator, Action completeEvent)
    {
        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsTag("Death") && stateInfo.normalizedTime >= 1;
        }
        );
        completeEvent?.Invoke();
    }
}
