using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        GameStateManager.GameState = GameState.Playing;
        gameObject.SetActive(false);
    }
}
