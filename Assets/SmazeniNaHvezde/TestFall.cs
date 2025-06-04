using System.Collections;
using UnityEngine;

public class TestFall : MonoBehaviour
{
    public Rigidbody rbPrefab;

    public float interval = 0.5f;
    public bool enabledSpawn = false;
    public float spread = .3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            transform.position += Vector3.up * 0.2f;
            if (enabledSpawn)
            {
                var rb = Instantiate(rbPrefab, GetPosition(), Quaternion.identity);
                //rb.transform.SetParent(transform);
                rb.transform.localScale *= Random.Range(.9f, 1.2f);
            }
            yield return new WaitForSeconds(interval);
        }
    }

    private Vector3 GetPosition()
    {
        return new Vector3(
            transform.position.x + Random.Range(-spread, spread),
            transform.position.y,
            transform.position.z
            );
    }
}
