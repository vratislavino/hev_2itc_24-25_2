using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UstecakSpawner : MonoBehaviour
{
    [SerializeField]
    private float interval;
    private int countdown = 3;

    [SerializeField]
    private List<Ustecak> prefabs;

    [SerializeField]
    private TMPro.TMP_Text countdownText;

    public bool skipCountdown;

    void Start()
    {
        StartCoroutine(SpawnUstecakRoutine());    
    }

    private IEnumerator SpawnUstecakRoutine()
    {
        if(!skipCountdown)
            for(int i = 0; i < 3; i++)
            {
                SetCountDown();
                yield return new WaitForSeconds(1);
            }
        countdownText.gameObject.SetActive(false);
        while (true)
        {
            SpawnUstecak();
            yield return new WaitForSeconds(interval);
        }
    }

    private void SpawnUstecak()
    {
        var prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Count)];
        var ustecak = Instantiate(prefab, transform);
        ustecak.transform.localPosition = Vector3.up * 0.5f;
        ustecak.transform.Rotate(0, UnityEngine.Random.Range(0f, 360f), 0);
    }

    private void SetCountDown()
    {
        countdownText.text = countdown.ToString();
        countdown--;
    }

}
