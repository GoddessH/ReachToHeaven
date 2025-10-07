using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "HurtState", menuName = "ScriptableObject/Character's States/HurtState")]
public class HurtState : StateLogic
{
    //
    public override void EnterState(StateContext context)
    {
        if (context is HurtStateContext hurtContext)
        {
            //Debug.Log("Entered HurtState");
            hurtContext.CharacterAnimatorController.CharacterAnimator.SetBool("isHurt", true);
            hurtContext.EnterEvent?.Invoke();
            hurtContext.RoutineCaller.
                StartCoroutine(Invinsible(hurtContext.CharacterAnimatorController, hurtContext.CompleteEvent));
        }
    }

    public override void ExitState(StateContext context)
    {
        if (context is HurtStateContext hurtContext)
        {
            hurtContext.CharacterAnimatorController.CharacterAnimator.SetBool("isHurt", false);
        }
    }

    private IEnumerator Invinsible(AnimatorController animatorController, Action completeEvent)
    {
        yield return new WaitUntil(()
            => 
            {
                AnimatorStateInfo currentStateInfo = animatorController.CharacterAnimator.GetCurrentAnimatorStateInfo(0);
                return (currentStateInfo.IsTag("Hurt") && currentStateInfo.normalizedTime >= 1);
            }
            );
        completeEvent?.Invoke();
    }
}
