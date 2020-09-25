using UnityEngine;

public enum GameState
{
    Start,
    Playing,
    Dead
}

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public SpikeManager spikeManager;
    public GameObject startScreen;
    public ScoreManager scoreManager;
    public GameObject deathScreen;

    public GameState GameState { get; set; } = GameState.Start;

    public bool IsState(GameState state) { return state == GameState; }

    public void Die()
    {
        GameState = GameState.Dead;
        scoreManager.UpdateHighScore();
        deathScreen.SetActive(true);
    }

    public void ResetGame()
    {
        spikeManager.Restart();
        player.Restart();
        scoreManager.Restart();
    }

    public void StartGame()
    {
        GameState = GameState.Playing;
        player.gameObject.GetComponent<Rigidbody2D>().gravityScale = 4.9f;
        startScreen.SetActive(false);
    }
}
