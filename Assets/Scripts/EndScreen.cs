using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public SpikeManager spikeManager;
    public PlayerController player;
    public ScoreManager scoreManager;

    public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        spikeManager.Restart();
        player.Restart();
        scoreManager.Restart();
        GameStateManager.GameState = GameState.Playing;
        gameObject.SetActive(false);
    }
}
