using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Attack")]
public class AttackAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var attackAgent = stateMachine.GetComponent<AttackAgent>();

        attackAgent.Ready();
    }
}
