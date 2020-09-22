using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public SpikeManager spikeManager;
    public PlayerController player;
    public ScoreManager scoreManager;

    public Text text;
    public Button startButton;

    public void StartGame()
    {
        // Resets if player is dead
        if (GameStateManager.IsState(GameState.Dead))
            ResetGame();

        GameStateManager.GameState = GameState.Playing;
        gameObject.SetActive(false);
        text.text = "Oof you died. Click the button to start again.";
    }

    private void ResetGame()
    {
        spikeManager.Restart();
        player.Restart();
        scoreManager.Restart();
    }
}
