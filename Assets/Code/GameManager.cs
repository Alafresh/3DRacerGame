using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public TextMeshProUGUI scoreText;

    int score = 0;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        gamePlayUI.SetActive(true);
        StartCoroutine(UpdateScore());
    }
    public void GameOver()
    {
        platformSpawner.SetActive(false);
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator  UpdateScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
    }
}
