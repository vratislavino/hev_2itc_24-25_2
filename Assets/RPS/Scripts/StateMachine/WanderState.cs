using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    public WanderState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void UpdateState()
    {
        // pokud agent dorazil na cil, zmen cil
        // jinak pokracuj v pohybu k cili
    }

    public override State TryToChangeState()
    {
        var colliders = Physics.OverlapSphere(agent.transform.position, RADIUS);

        var symbols = colliders.Select(c => c.GetComponentInParent<RPSSymbol>());
        symbols = symbols
            .Where(s => s != null)
            .Where(s => s.transform != agent.transform);
        
        if(symbols.Count() > 0)
        {
            var wouldWin = symbols.First();
            if(wouldWin)
                return new AggroState(agent);
            else 
                return new FleeState(agent);
        }
        return this;
    }
}
