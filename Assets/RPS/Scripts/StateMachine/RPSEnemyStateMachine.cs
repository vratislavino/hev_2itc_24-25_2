using UnityEngine;
using UnityEngine.AI;

public class RPSEnemyStateMachine : MonoBehaviour
{
    State currentState;

    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        currentState = new WanderState(agent);
        currentState.InitState();
    }

    void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState();
            var newState = currentState.TryToChangeState();
            if(newState != currentState)
            {
                currentState = newState;
                currentState.InitState();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(currentState != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, currentState.Radius);
        }
    }
}
