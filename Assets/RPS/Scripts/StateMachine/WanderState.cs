using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    Vector3 destination;

    public WanderState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void UpdateState()
    {
        if(Vector3.Distance(agent.transform.position, destination) < 1)
        {
            destination = RandomNavmeshLocation();
            agent.SetDestination(destination);
        }
    }

    private Vector3 RandomNavmeshLocation()
    {
        int x, y, z;
        x = Random.Range(0, 100);
        y = 100;
        z = Random.Range(0, 100);
        
        if(Physics.Raycast(new Vector3(x,y,z), Vector3.down, out RaycastHit hit, 105f))
        {
            if (hit.collider.name.Contains("Terrain"))
            {
                return hit.point;
            } else
            {
                return RandomNavmeshLocation();
            }
        } else
        {
            return RandomNavmeshLocation();
        }
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
            var enemySymbol = symbols.First();
            var wouldWin = mySymbol.CurrentSymbol.WouldWin(enemySymbol.CurrentSymbol);

            if (wouldWin == null)
                return this;

            if(wouldWin.Value)
                return new AggroState(agent, enemySymbol);
            else 
                return new FleeState(agent, enemySymbol);
        }
        return this;
    }
}
