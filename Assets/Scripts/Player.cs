using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int speed;
    public int score;
    public GameObject coin;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RestartGame();
        ScreenThreshold();
        HorizontalMovement();
        VerticalMovement();
    }

    void RestartGame()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void ScreenThreshold()
    {
        if(transform.position.x > 8.5f || transform.position.x < -8.5f || transform.position.y > 4.5f || transform.position.y < -4.5f)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    void HorizontalMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed; // returns 1 if we are pressing D or -1 if we are pressing A

        if (horizontal < 0.0f) // if we are moving left
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (horizontal > 0.0f) // if we are moving right
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    void VerticalMovement()
    {
        vertical = Input.GetAxisRaw("Vertical") * speed; // returns 1 if we are pressing W or -1 if we are pressing S

        if (vertical < 0.0f) // if we are moving down
        {
            transform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
        }
        else if (vertical > 0.0f) // if we are moving up
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, vertical); // update the position
    }

    void OnTriggerEnter2D(Collider2D coin) // collision with a coin
    {
        score += 1;
        Destroy(coin.gameObject);
    }
}
