using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    float health = 100;

    bool isPlayer;
    bool isEnemy;
    public bool isDead;

    private void Start()
    {
        isDead = false;
    }

    public void DoDamage(float damageAmount)
    {
        if (!isDead && health > 0)
        {
             health -= damageAmount;
            print("Damage Taken");
        }
        if(health <= 0)
        {
            isDead = true;
            Die();
        }
        
    }

    void Die()
    {
        print("EnemyDead");
    }
}
