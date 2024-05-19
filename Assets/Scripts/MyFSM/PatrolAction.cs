using System.Collections;
using UnityEngine.AI;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
public class PatrolAction : FSMAction
{
    public override void OnEnter(BaseStateMachine stateMachine)
    {
        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
        Debug.Log("Action1");
        patrolAgent.SetDestination(patrolPoints.GetNext());
    }

    public override void Execute(BaseStateMachine stateMachine)
    {
        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
        Debug.Log("Action2");
        if (patrolPoints.HasReached(patrolAgent))
            patrolAgent.SetDestination(patrolPoints.GetNext());
    }
}
