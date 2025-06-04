using UnityEngine;

public class Sticker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        return;
        if(collision.collider.name.StartsWith("Cube"))
        {
            Debug.Log("WHET?");
            var rb = collision.collider.GetComponent<Rigidbody>();
            var joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = rb;
            joint.breakForce = 100;
            joint.breakTorque = 100;
        }
    }

    private void Start()
    {
        Invoke("FreezeMe", 5f);
    }

    void FreezeMe()
    {
        GetComponent<Rigidbody>().constraints = 
            RigidbodyConstraints.FreezePositionX | 
            RigidbodyConstraints.FreezeRotation | 
            RigidbodyConstraints.FreezePositionZ;
    }

    private void OnJointBreak(float breakForce)
    {
        print("Joint broke with force: " + breakForce);

    }
}
