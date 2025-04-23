using System;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public event Action EnemyDestroyed;

    bool isDestroyed = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(isDestroyed) return;
        isDestroyed = true;

        EnemyDestroyed?.Invoke();
        Destroy(gameObject);

    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up, 100f * Time.fixedDeltaTime);
    }
}
