using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private float force = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponentInParent<Rigidbody>().AddForce(Vector3.up * force);
        }
    }
}
