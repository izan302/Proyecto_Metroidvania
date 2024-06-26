using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public sealed class State : BaseState
{
    public List<FSMAction> Action = new List<FSMAction>();
    public List<Transition> Transitions = new List<Transition>();

    public override void OnEnter(BaseStateMachine machine)
    {
        foreach (var action in Action)
            action.OnEnter(machine);
    }

    public override void OnExit(BaseStateMachine machine)
    {
        foreach (var action in Action)
            action.OnExit(machine);
    }

    public override void Execute(BaseStateMachine machine)
    {
        foreach (var action in Action)
            action.Execute(machine);

        foreach(var transition in Transitions)
            transition.Execute(machine);
    }
}
