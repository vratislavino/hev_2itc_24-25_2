
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class FleeState : State
{
    private RPSSymbol target;
    public FleeState(NavMeshAgent agent, RPSSymbol target) : base(agent)
    {
        this.target = target;
        this.agent.speed = 4f;
        Debug.Log("You're hella strong, I'm leavin'");
    }

    public override void UpdateState()
    {
        if (target != null)
        {
            Vector3 targetPos = new Vector3(
                agent.transform.position.x - target.transform.position.x,
                target.transform.position.y,
                agent.transform.position.z - target.transform.position.z
                );

            agent.SetDestination(targetPos);
        }
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
                return new AggroState(agent, enemySymbol);
            else
                return this;
        }
        return new WanderState(agent);
    }
}
