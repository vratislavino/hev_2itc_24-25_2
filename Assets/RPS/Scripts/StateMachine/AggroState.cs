using UnityEngine;
using UnityEngine.AI;

public class AggroState : State
{
    private RPSSymbol target;

    public AggroState(NavMeshAgent agent, RPSSymbol target) : base(agent)
    {
        this.target = target;
        this.agent.speed = 8f;//Random.Range(3f,8f);
    }

    public override void UpdateState()
    {
        Debug.Log("Im gonna get your ass");
        agent.SetDestination(target.transform.position);
    }

    public override State TryToChangeState()
    {

        return this;
    }
}
