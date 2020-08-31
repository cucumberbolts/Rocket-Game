using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public SpikeManager spikeManager;
    public PlayerController player;

    public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        spikeManager.Restart();
        player.Restart();
        GameStateManager.GameState = GameState.Playing;
        gameObject.SetActive(false);
    }
}
