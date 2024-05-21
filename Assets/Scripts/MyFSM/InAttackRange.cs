using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/In Attack Range")]
public class InAttackRange : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        var enemyInLineOfSight = stateMachine.GetComponent<EnemySightSensor>();
        return enemyInLineOfSight.Slash();
    }
}
