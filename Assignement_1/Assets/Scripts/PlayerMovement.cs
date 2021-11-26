using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField]
    private Animator animator;
    private Rigidbody2D playerBody;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float jumpHeight = 5f;

    [HideInInspector]
    public float playerXdir;
    private bool canMove = true;
    private bool canJump = true;

    private int jumpCount = 1;
    [SerializeField]
    private int maxJumpLimit = 2;

    [HideInInspector]
    public bool facingRight = true;

    void Awake(){
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(canMove){
            playerXdir = Input.GetAxis("Horizontal");
            MovePlayer();
            Jump();
        }
    }

    void MovePlayer(){
        animator.SetFloat("walk", Mathf.Abs(playerXdir));

        playerBody.velocity = new Vector2(moveSpeed*playerXdir, playerBody.velocity.y);

        if(facingRight && playerXdir<0){
            Flip();
        }else if(!facingRight && playerXdir>0){
            Flip();
        }
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && canJump && jumpCount<maxJumpLimit){
            playerBody.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);

            jumpCount++;
        }
    }

    void Flip(){
        facingRight = !facingRight;
        transform.localScale = new Vector2(transform.localScale.x*-1, transform.localScale.y);
    }

    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.layer == 6){
            jumpCount = 1;
        }
    }
}
