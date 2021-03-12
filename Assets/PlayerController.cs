using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;

    public float moveSpeed =100;
    public int jumpHeight = 1250;
    private bool facingRight = false;
    private float moveX = 0;

    void Update()
    {
       PlayerMove();
    }

    void PlayerMove(){

        if(Input.GetKey(KeyCode.A)){
            moveX=-5;
            rb.velocity = new Vector2(moveX,rb.velocity.y);
            transform.localScale = new Vector2(-1.5f,1.5f);
        }

        if(Input.GetKey(KeyCode.D)){
            moveX=5;
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

