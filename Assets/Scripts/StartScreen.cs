using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public SpikeManager spikeManager;
    public PlayerController player;
    public ScoreManager scoreManager;

    public GameManager gameManager;

    public Text text;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.StartGame();
            text.text = "Oof you died. Press the space bar\nor the up arrow to start again.";
        }
    }
}
