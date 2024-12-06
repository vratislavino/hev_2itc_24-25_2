using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RPSPlayer : MonoBehaviour
{
    Camera camera;
    NavMeshAgent agent;
    RPSSymbol symbol;

    [SerializeField] float interval = 5f;

    void Start()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        symbol = GetComponent<RPSSymbol>();
        StartCoroutine(ChangeSymbolRoutine());
    }

    private IEnumerator ChangeSymbolRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            symbol.ChangeSymbolToRandom();
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 150f))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
