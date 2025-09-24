using System;
using UnityEngine;

public abstract class StateContext
{
    //External system can subscribe any method and states will callback them
    public Action EnterEvent, CompleteEvent;

    public AnimatorController CharacterAnimatorController;

}
