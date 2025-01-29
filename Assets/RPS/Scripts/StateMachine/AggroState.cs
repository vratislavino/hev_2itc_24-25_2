using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AggroState : State
{
    private RPSSymbol target;

    public AggroState(NavMeshAgent agent, RPSSymbol target) : base(agent)
    {
        this.target = target;
        this.agent.speed = 8f;//Random.Range(3f,8f);
        Debug.Log("Im gonna get your ass");
    }

    public override void UpdateState()
    {
        if(target != null) 
            agent.SetDestination(target.transform.position);
    }

    public override State TryToChangeState()
    {
        var colliders = Physics.OverlapSphere(agent.transform.position, RADIUS);

        var symbols = colliders.Select(c => c.GetComponentInParent<RPSSymbol>());
        symbols = symbols
            .Where(s => s != null)
            .Where(s => s.transform != agent.transform);

        if (symbols.Count() > 0)
        {
            var enemySymbol = symbols.First();
            var wouldWin = mySymbol.CurrentSymbol.WouldWin(enemySymbol.CurrentSymbol);

            if (wouldWin == null)
                return new WanderState(agent);

            if (wouldWin.Value)
                return this;
            else
                return new FleeState(agent, enemySymbol);
        }
        return new WanderState(agent);
    }
}
