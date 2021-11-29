using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            Debug.Log(gameObject.name + " Got Destroyed...");
            Destroy(this.gameObject);
        }
    }
}