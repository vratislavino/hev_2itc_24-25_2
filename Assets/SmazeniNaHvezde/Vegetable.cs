using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectsByType<DeathScreen>(FindObjectsSortMode.None)[0].ShowDeathScreen();
            Time.timeScale = 0;
        }
    }
}
