using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float flyForce;
    public float rotation;  // How much player rotates

    public uint dieForce;

    public GameObject startScreen;

    public ScoreManager scoreManager;

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

            // Rotates ship
            float angle = Mathf.Atan(rb2d.velocity.y / rotation) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    private void Die()
    {
        GameStateManager.GameState = GameState.Dead;
        startScreen.SetActive(true);
        rb2d.AddForce(new Vector2(Random.Range(-10, dieForce), Random.Range(10, dieForce)));

        scoreManager.UpdateHighScore();
    }

    public void Restart()
    {
        transform.position = startPosition;
        rb2d.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameStateManager.IsState(GameState.Playing))
            Die();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameStateManager.IsState(GameState.Playing))
            // Detects if player passes the spike
            if (collision.CompareTag("Spike"))
                //scoreManager.Score++;
                scoreManager.Score++;
    }
}
