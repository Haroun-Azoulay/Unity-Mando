using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasjameSonerenScript : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float time;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private bool movingRight = true;

    int dirValue = 0;

    // Start is called before the first frame update
    void Start()
    {

        startPosition = transform.localPosition;
        iTween.MoveTo(gameObject, iTween.Hash(
            "position", endPosition,
            "time", time,
            "looptype", iTween.LoopType.pingPong,
            "easetype", iTween.EaseType.linear,
            "islocal", true,
            "onupdate", "OnMoveUpdate"
        ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMoveUpdate()
    {

        if (transform.localPosition.x >= endPosition.x && movingRight)
        {
            // Change direction to right
            movingRight = false;
            spriteRenderer.flipX = true;
            dirValue = 1;
        }
        else if (transform.localPosition.x <= startPosition.x && !movingRight)
        {        
            // Change direction to left
            movingRight = true;
            spriteRenderer.flipX = false;
            dirValue = 1;
        }
    }
      public void HandleMove()
    {
        animator.SetInteger("dir", dirValue);
    }
}
