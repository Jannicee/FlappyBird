using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameStarted = false;
    private bool isGameOver = false;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isGameStarted = false;
        isGameOver = false;
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        if (isGameStarted) return;
        isGameStarted = true;

        UIManager.Instance.HideStartPanel();
        UIManager.Instance.HideGameOverPanel();
        UIManager.Instance.ShowGameplayPanel();
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0f;
        int FinalScore = ScoreManager.Instance.GetCurrentScore();
        UIManager.Instance.ShowGameOverPanel(FinalScore);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        isGameStarted = false;
        isGameOver = false;
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
