using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_move : MonoBehaviour {

    public float moveSpeed =10;
    public int jumpHeight = 1250;
    private bool facingRight = false;
    private float moveX;

    void Update()
    {
       PlayerMove();
    }

    void PlayerMove(){

        moveX=Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump")){
            Jump();
        }

        if(moveX<0.0f && facingRight==false)
        {
            flipPlayer();
        }
        else if(moveX>0.0f && facingRight==true)
        {
            flipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); 

    }

void Jump(){
    GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpHeight);
}

void flipPlayer(){
facingRight=!facingRight;
Vector2 localScale = gameObject.transform.localScale;
localScale.x *= -1;
transform.localScale= localScale;
}

}

