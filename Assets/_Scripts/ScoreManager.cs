using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string ScoreKey = "SavedScore";
    private const string BestScoreKey = "SavedBestScore";
    UIHandler uih;
    BestScoreHandler bsh;

    public int Score {get; private set;}
    public int BestScore {get; private set;}

    private void Awake()
    {
        uih = GameObject.Find("UI").GetComponent<UIHandler>();
        bsh = GameObject.Find("BestScoreUI").GetComponent<BestScoreHandler>();
        Score = PlayerPrefs.GetInt(ScoreKey, 0);
        BestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        uih.UpdateScore();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, Score);
        PlayerPrefs.Save();
        uih.UpdateScore();
    }

    public void ResetScore(bool roundReset = false)
    {
        if (roundReset && BestScore == 0)
        {
            PlayerPrefs.SetInt(BestScoreKey, Score);
            bsh.UpdateScore();
        } else if (roundReset && Score < BestScore && BestScore !=0)
        {
            PlayerPrefs.SetInt(BestScoreKey, Score);
            bsh.UpdateScore();
        }
        Score = 0;
        SaveScore();
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            SaveScore();
        }
    }

    private void OnApplicationQuit()
    {
        SaveScore();
    }
}