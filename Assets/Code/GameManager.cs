using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables publicas

    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public GameObject menuUI;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseMenu;

    AudioSource audioS;
    public AudioClip[] gameMusics;

    int score = 0;
    int highScoreInt = 0;

    public bool gameIsPaused = false;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        audioS = GetComponent<AudioSource>();
    }
    private void Start()
    {
        highScoreInt = PlayerPrefs.GetInt("HighScore");
        highScore.text = "Best Score : " + highScoreInt;

        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);

        audioS.clip = gameMusics[1];
        audioS.Play();

        StartCoroutine("UpdateScore");
    }
    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGame()
    {   
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
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

    public void IncrementScore()
    {
        score += 2;
        scoreText.text = score.ToString();

        audioS.PlayOneShot(gameMusics[2], 0.5f);
    }

    void SaveHighScore()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
