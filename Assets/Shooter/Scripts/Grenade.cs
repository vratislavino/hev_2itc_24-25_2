using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    float range = 5f;
    public float force = 1000f;
    void Start()
    {
        StartCoroutine(DelayedExplosion());            
    }

    IEnumerator DelayedExplosion()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Explode();
        }
    }

    private void Explode()
    {
        var colliders = Physics.OverlapSphere(transform.position, range);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.AddExplosionForce(force, transform.position, range);
            }
        }
    }

}
