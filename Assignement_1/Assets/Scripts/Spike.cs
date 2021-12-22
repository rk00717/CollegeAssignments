using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour{
    [SerializeField]
    private int hitPoint;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            Debug.Log("Got him ::: " + collider.name);
            collider.gameObject.GetComponent<HealthManager>().TakeDamage(hitPoint);
        }
    }
}
