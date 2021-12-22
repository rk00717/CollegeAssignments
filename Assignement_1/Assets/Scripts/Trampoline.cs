using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour{
    private Animator animator;
    private BoxCollider2D collider;

    private Vector2 extendSize = new Vector2(2.3f, 2.6f);
    // private Vector2 extendSizeOffset = new Vector2(-0.05f, -0.11f);

    private Vector2 normalSize = new Vector2(2.4f, 0.7f);
    // private Vector2 normalSizeOffset = new Vector2(-0.05f, -1f);

    void Awake(){
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            animator.SetTrigger("FireTrampoline");
            collider.size = extendSize;
            // collider.offset = extendSizeOffset;
        }
    }
    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            collider.size = normalSize;
            // collider.offset = normalSizeOffset;
        }
    }
}
