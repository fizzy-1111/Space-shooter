using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDeath;
    public static StartGameDelegate onResume;
    public delegate void TakeDmgDelegate(float ex);
    public static TakeDmgDelegate onTakeDmg;
    public delegate void OthersDeathDelegate();
    public static OthersDeathDelegate onOthersDeath;
    public delegate void ScorePointDelegate(int Score);
    public static ScorePointDelegate onScorePoint;
    public static void StartGame()
    {
        if (onStartGame != null)
            onStartGame();
    }
    public static void TakeDmg(float percent)
    {
        if (onTakeDmg != null) onTakeDmg(percent);
    }
    public static void PlayerDeath()
    {
        if (onPlayerDeath != null)
            onPlayerDeath();
    }
    public static void ScorePoint(int Score)
    {
        if (onScorePoint != null)
            onScorePoint(Score);
    }
    public static void OthersDeath()
    {
        if (onOthersDeath != null) onOthersDeath();
    }
    public static void ReSume()
    {
        if (onResume != null)
            onResume();
    }

}
