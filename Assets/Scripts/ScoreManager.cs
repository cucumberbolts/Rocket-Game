using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    private void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
        Restart();
    }

    public void Restart()
    {
        Score = 0;
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }
}
