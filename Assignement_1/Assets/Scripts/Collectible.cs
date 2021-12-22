using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour{
    [SerializeField]
    private int healthPoint;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            collider.gameObject.GetComponent<HealthManager>().AddHP(healthPoint);
            Destroy(this.gameObject);
        }
    }
}