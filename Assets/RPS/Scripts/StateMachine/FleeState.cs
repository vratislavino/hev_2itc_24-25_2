
using UnityEngine;
using UnityEngine.AI;

public class FleeState : State
{
    public FleeState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void UpdateState()
    {
        Debug.Log("You're hella strong, I'm leavin'");
    }

    public override State TryToChangeState()
    {
        return this;
    }
}
