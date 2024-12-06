using UnityEngine;

public class RPSCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    Vector3 offset;

    void Start()
    {
        offset = player.position - transform.position;
    }

    void Update()
    {
        transform.position = player.position - offset;
    }
}
