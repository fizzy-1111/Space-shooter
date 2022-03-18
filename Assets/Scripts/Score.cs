using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text HighScoreText;
    [SerializeField] Text ScoreText;
    [SerializeField] int HighScore;
    [SerializeField] int score;
    private void OnEnable()
    {
        EventManager.onStartGame += ResetScore;
        EventManager.onScorePoint += AddScore;
    }
    private void Update()
    {
        LoadHighScore();
        //PlayerPrefs.SetInt("HiScore", 0);
    }
    private void OnDisable()
    {
        EventManager.onStartGame -= ResetScore;
        EventManager.onScorePoint -= AddScore;
    }
    private void ResetScore()
    {
        score = 0;
        DisplayScore();
        DisplayHighScore();
    }
    void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HiScore", 0);
    }
    void CheckNewHighScore()
    {
        if (score >= HighScore)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HiScore", HighScore);
        }
    }
    void DisplayScore()
    {
        ScoreText.text = score.ToString();
    }
    void DisplayHighScore()
    {
        HighScoreText.text = HighScore.ToString();
    }
    void AddScore(int addScore)
    {
        score += addScore;
        CheckNewHighScore();
        DisplayHighScore();
        DisplayScore();
    }
}
