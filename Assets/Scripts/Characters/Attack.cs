using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public float rayDistance;
    Animator animator;

    float coolDownTime;
    float coolTimer;
    public float damage = 10;

    public LayerMask playerMask;

    bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        rayDistance = 1.2f;
        damage = 5;
        animator = GetComponentInChildren<Animator>();
        coolDownTime = Random.Range(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
    }

    void AttackPlayer()
    {
        if (coolTimer > 0)
        {
            coolTimer -= Time.deltaTime;
        }
        if(coolTimer <= 0)
        {
            attacking = false;
        }

        if (!attacking)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, playerMask))
            {
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.tag == "Player")
                {
                    animator.SetTrigger("attack");
                    hit.transform.GetComponent<HealthManager>().DoDamage(damage);
                    print("Hit " + hit.transform.gameObject.name);
                    coolTimer = coolDownTime;
                    attacking = true;
                }
                
            }
            

        }

    }

    
}
