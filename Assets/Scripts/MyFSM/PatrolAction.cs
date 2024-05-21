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
        patrolAgent.SetDestination(patrolPoints.GetNext().position);
    }

    public override void Execute(BaseStateMachine stateMachine)
    {
        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
        if (patrolAgent.remainingDistance <= patrolAgent.stoppingDistance) {
            var patrolPoint = patrolPoints.GetNext().position;
            patrolAgent.SetDestination(patrolPoint);
        }
            
    }
}
