
using UnityEngine;
using UnityEngine.AI;

public class FleeState : State
{
    private RPSSymbol target;
    public FleeState(NavMeshAgent agent, RPSSymbol target) : base(agent)
    {
        this.target = target;
        this.agent.speed = 8f;
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
