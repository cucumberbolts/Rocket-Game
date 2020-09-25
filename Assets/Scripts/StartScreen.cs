using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameManager gameManager;

    public Text text;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            gameManager.StartGame();
    }
}
