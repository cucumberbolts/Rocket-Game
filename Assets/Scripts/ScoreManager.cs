using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private uint score = 0;
    public Text text;

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        score = 0;
        text.text = "0";
    }

    public void IncrementScore()
    {
        score++;
        text.text = score.ToString();
    }
}
