using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    float health = 100;
    public AudioSource HitAudio;

    public bool isPlayer;
    public bool isEnemy;
    public bool isDead;

    private void Start()
    {
        HitAudio = GetComponent<AudioSource>();
        isDead = false;
    }

    public void DoDamage(float damageAmount)
    {
        if (isEnemy)
        {
            HitAudio.Play();
        }
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
