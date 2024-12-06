using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGenerator : MonoBehaviour
{
    public float interval;
    public float distance;
    public GameObject eggPrefab;

    void Start()
    {
        StartCoroutine(GenerateObject());
    }

    IEnumerator GenerateObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            CreateObject();
        }
    }

    private void CreateObject()
    {
        var egg = Instantiate(eggPrefab, transform);
        Destroy(egg, 5f); 

        egg.transform.localPosition = new Vector3(
            Random.Range(-distance, distance),
            0,
            Random.Range(-distance, distance)
            );

        egg.transform.rotation = Quaternion.Euler(new Vector3(
            Random.Range(0, 360),
            Random.Range(0, 360),
            Random.Range(0, 360)
            ));

        Rigidbody rb = egg.GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(
            Random.Range(10,50),
            Random.Range(10,50),
            Random.Range(10,50)
            ));
    }
}
