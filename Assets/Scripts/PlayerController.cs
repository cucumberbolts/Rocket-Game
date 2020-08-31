using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float flyForce;
    public float rotation;  // How much player rotates

    public uint dieForce;

    public GameObject restartScreen;

    // Use this for resetting the game
    private Vector3 startPosition;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        startPosition = transform.position;
    }

    void Update()
    {
        if (GameStateManager.IsState(GameState.Playing))
        {
            rb2d.gravityScale = 4.9f;

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
                rb2d.AddForce(Vector2.up * flyForce * Time.deltaTime * 1000f);
        }

        // Rotates ship            opposite        adjacent
        float angle = Mathf.Atan(rb2d.velocity.y / rotation) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Die()
    {
        GameStateManager.GameState = GameState.Dead;
        restartScreen.SetActive(true);
        rb2d.AddForce(new Vector2(Random.Range(-10, dieForce), Random.Range(10, dieForce)));
        Restart();
    }

    public void Restart()
    {
        transform.position = startPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameStateManager.IsState(GameState.Playing))
            Die();
    }
}
