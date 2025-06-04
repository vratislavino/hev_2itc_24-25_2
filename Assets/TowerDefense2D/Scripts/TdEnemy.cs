using System;
using UnityEngine;

public class TdEnemy : MonoBehaviour
{
    Transform currentWaypoint;
    Rigidbody2D rb;

    [SerializeField]
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(currentWaypoint == null)
        {
            currentWaypoint = TdWaypointProvider.Instance.GetNextWaypoint(currentWaypoint);
        }
        
        Vector3 direction = (currentWaypoint.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        

        if(Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            currentWaypoint = TdWaypointProvider.Instance.GetNextWaypoint(currentWaypoint);
        }
    }

    internal void TakeDamage(float damage)
    {
        // TODO: Lets make hp system for enemies 
        Debug.Log($"Enemy took {damage} damage");
        Destroy(gameObject);
    }
}
