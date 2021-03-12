using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;

    public float moveX;
    public int jumpHeight = 1250;
    private bool facingRight = false;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    void Update()
    {
       PlayerMove();
       if(rb.velocity.y<0)
       {
           rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1) * Time.deltaTime;           
       }
       else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
       {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier-1) * Time.deltaTime; 
       }
    }

    void PlayerMove(){

        if(Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-moveX,rb.velocity.y);
            transform.localScale = new Vector2(-1.5f,1.5f);
        }

        if(Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector2(moveX,rb.velocity.y);
            transform.localScale = new Vector2(1.5f,1.5f);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x,jumpHeight);
        }

        if(moveX<0.0f && facingRight==false)
        {
            flipPlayer();
        }
        else if(moveX>0.0f && facingRight==true)
        {
            flipPlayer();
        }
    }

void flipPlayer(){
facingRight=!facingRight;
Vector2 localScale = gameObject.transform.localScale;
localScale.x *= -1;
transform.localScale= localScale;
}

}

