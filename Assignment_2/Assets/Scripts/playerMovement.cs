using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour{
    private Rigidbody2D body;

    [Range(1,10)]
    [SerializeField]
    private float jumpHeight = 0f;
    private bool canJump = true;

    void Start(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetButtonDown("Jump") && canJump){
            body.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            canJump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Void"){
            Debug.Log("BlackHole got us.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 6){
            canJump = true;
        }
    }
}