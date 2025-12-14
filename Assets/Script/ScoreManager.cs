using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int CurrentScore = 0;
    
    public static ScoreManager Instance {get; private set;}

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
    public void AddScore(int value)
    {
        CurrentScore += value;
        //Debug.Log("Value : " + CurrentScore);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScoreDisplay(CurrentScore);
        }
    }

    public int GetCurrentScore()
    {
        return CurrentScore;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}
