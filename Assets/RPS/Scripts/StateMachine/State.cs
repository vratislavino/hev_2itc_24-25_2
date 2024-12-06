using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent agent;
    protected const float RADIUS = 10f;
    public float Radius => RADIUS;

    public State(NavMeshAgent agent)
    {
        this.agent = agent;
    }

    public virtual void InitState() { }

    public abstract void UpdateState();

    public abstract State TryToChangeState();
}
