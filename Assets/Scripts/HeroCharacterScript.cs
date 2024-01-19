using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HeroCharacterScript : MonoBehaviour
{


    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;

    Vector2 dir;

    int dirValue = 0;//0 = idl, 1 = down, 2 = side, 3 = up

    public Animator animator;

    public SpriteRenderer SpriteRenderer;
    
    
    // Update is called once per frame
    void Update()
    {
        HandleKeys();
        HandleMove();

    }

    // functions custom

    public void HandleKeys(){
              if(Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
            dirValue = 3;
        }
         else if(Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
            dirValue = 1;
        }
         else if(Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
            dirValue = 2;
            SpriteRenderer.flipX = false;
        }
         else if(Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
            dirValue = 2;
            SpriteRenderer.flipX = true;
        }
        else 
        {
            dir = Vector2.zero;
            dirValue = 0;
        }

    }
    // move manage
    public void HandleMove()
    {
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
        animator.SetInteger("dir", dirValue);
    }
}
