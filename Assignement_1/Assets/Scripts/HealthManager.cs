using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour{
    private int HP;
    [SerializeField]
    private int maxHealth;
    private int minHealth = 0;

    // public HealthManager(maxHealth){
    //     HP = maxHealth;
    //     this.maxHealth = maxHealth;
    // }

    void Awake(){
        HP = maxHealth;
    }

    public void TakeDamage(int health){
        if(HP >= 0){
            HP -= health;
        }

        HP = Mathf.Clamp(HP, minHealth, maxHealth);
    }

    public void AddHP(int health){
        if(HP <= maxHealth){
            HP += health;
        }

        HP = Mathf.Clamp(HP, minHealth, maxHealth);
    }

    public int GetHealth(){
        return HP;
    }
}