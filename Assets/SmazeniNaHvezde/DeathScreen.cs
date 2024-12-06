using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    float time = 0;

    public TMP_Text timeText;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        UpdateText();
    }

    void Update()
    {
        time += Time.deltaTime;
        UpdateText();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateText()
    {
        timeText.text = $"Your time: {time.ToString("F2")}";
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }
}
