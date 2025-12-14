using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject GameplayPanel;
    
    [Header ("UI Text")]
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI ScoreTextRealTime;
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        if (ScoreTextRealTime == null)
        {
            var canvas = FindObjectOfType<Canvas>();
            if (canvas != null)
            {
                var target = canvas.transform.Find("Panel Gameplay/Score Realtime");
                if (target != null)
                {
                    ScoreTextRealTime = target.GetComponent<TextMeshProUGUI>();
                }
            }
        }
    }
    public void UpdateScoreDisplay(int currentScore)
    {
        if (ScoreTextRealTime != null)
        {
            ScoreTextRealTime.text = currentScore.ToString();
        }
    }

    private void Start()
    {
        ShowStartPanel();
        HideGameOverPanel();
    }

    public void ShowStartPanel()
    {
        if (StartPanel != null)
        {
            StartPanel.SetActive(true);
        }
    }

    public void HideStartPanel()
    {
        if (StartPanel != null)
        {
            StartPanel.SetActive(false);
        }
    }

    public void HideGameOverPanel()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(false);
        }
    }

    public void ShowGameOverPanel(int FinalScore)
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
        }
        if (ScoreText != null)
        {
            ScoreText.text = FinalScore.ToString();
        }
    }

    public void ShowGameplayPanel()
    {
        if (GameplayPanel != null)
        {
            GameplayPanel.SetActive(true);
        }
    }

}
