using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public Animator anim;

    public Transform respawnPoint;

    public GameOver GameOver;

    public GameOver snowgie;

    public float moveX;

    public int jumpHeight = 1250;

    private bool facingRight = false;

    public float fallMultiplier = 2.5f;

    public float lowJumpMultiplier = 2f;

    public int candies = 0;

    public Text candyAmount;

    public int lives = 3;

    public Text lifeAmount;

    void Update()
    {
        PlayerMove(); // For Character movement

        if (
            rb.velocity.y > 0 // To Stop player blink animation after respwan
        )
        {
            anim.SetBool("hurt", false);
        }

        if (
            Input.anyKeyDown // To Hide the snowgie dialogue once player moves off the area
        )
        {
            snowgie.Setup(false);
        }
        GameOverScreen(); // Ivoked When all lives are consumed
    }

    void PlayerMove()
    {
        // left movement & animation
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveX, rb.velocity.y);
            transform.localScale = new Vector2(-1.5f, 1.5f);
            anim.SetBool("running", true);
        } // right movement & animation
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveX, rb.velocity.y);
            transform.localScale = new Vector2(1.5f, 1.5f);
            anim.SetBool("running", true);
        }
        else
        // idle animation
        {
            anim.SetBool("running", false);
        }

        // jump logic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.velocity.y == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
        }

        // for better character jump (long jump on long press)
        if (rb.velocity.y < 0)
        {
            rb.velocity +=
                Vector2.up *
                Physics2D.gravity.y *
                (fallMultiplier - 1) *
                Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity +=
                Vector2.up *
                Physics2D.gravity.y *
                (lowJumpMultiplier - 1) *
                Time.deltaTime;
        }

        // flip left if movement left
        if (moveX < 0.0f && facingRight == false)
        {
            flipPlayer();
        } // flip right if movement right
        else if (moveX > 0.0f && facingRight == true)
        {
            flipPlayer();
        }
    }

    // Flip player logic
    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    //To collect candies and the final snowgie interaction
    public void OnTriggerEnter2D(Collider2D collide)
    {
        // Good candies logic
        if (collide.tag == "Gcandies")
        {
            Destroy(collide.gameObject);
            candies += 1;
            candyAmount.text = candies.ToString();
        }

        // Bad candies logic
        if (collide.tag == "Bcandies")
        {
            Destroy(collide.gameObject);
            candies -= 1;
            candyAmount.text = candies.ToString();
        }

        // Interaction with sowgie
        if (
            (collide.tag == "snowgie") && (candies < 10) //  show dialogue if candies < 10
        )
        {
            snowgie.Setup(true);
        }
        else if (
            (collide.tag == "snowgie") && (candies >= 10) // Congratulations Scene
        )
        {
            SceneManager.LoadScene("level1");
        }
    }

    // Player life decrement if in contact with Fire and Yeti
    public void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Yeti")
        {
            // kill Yeti if Player is falling (jumping on head)
            if (rb.velocity.y < 0)
            {
                Destroy(player.gameObject);
            } // players life reduced
            else
            {
                lives -= 1;
                lifeAmount.text = lives.ToString();
                anim.SetBool("hurt", true); // player blink animation
                rb.gameObject.transform.position = respawnPoint.position;
            }
        }
        if (
            player.gameObject.tag == "Fire" // players life reduced
        )
        {
            lives -= 1;
            lifeAmount.text = lives.ToString();
            anim.SetBool("hurt", true); // player blink animation
            rb.gameObject.transform.position = respawnPoint.position;
        }
    }

    void GameOverScreen()
    {
        if (lives == 0)
        {
            anim.SetBool("hurt", false); // To stop player blink animation
            GameOver.Setup(true); // display gameOver scene
            snowgie.Setup(false); // hide snowgie interaction dialogue
            Destroy (rb);
            candyAmount.text = "0";
        }
    }
}
