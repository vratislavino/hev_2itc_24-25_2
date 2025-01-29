using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent agent;
    protected RPSSymbol mySymbol;

    protected const float RADIUS = 10f;
    public float Radius => RADIUS;

    public State(NavMeshAgent agent)
    {
        this.agent = agent;
        mySymbol = agent.GetComponent<RPSSymbol>();
    }

    public virtual void InitState() { }

    public abstract void UpdateState();

    public abstract State TryToChangeState();
}
