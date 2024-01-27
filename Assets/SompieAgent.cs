using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SompieAgent : MonoBehaviour
{
    HealthManager healthManager;

    Transform eyes;
    Transform player;
    [SerializeField]
    float radius;
    public float followTimerAmount;
    float followTimer;
    NavMeshAgent agent;

    public LayerMask playerMask;
    [SerializeField]
    bool seePlayer;
    bool followPlayer;
    bool isDead;

    Vector3 SompieVelocity;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        eyes = transform.Find("Eyes");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            agent.enabled = false;
        }
        if (!isDead)
        {
            isDead = healthManager.isDead;
            SompieVelocity = agent.velocity;

            if (Physics.CheckSphere(transform.position, radius, playerMask))
            {
                seePlayer = true;
            }
            else
            {
                seePlayer = false;
            }



            if (seePlayer)
            {
                followPlayer = true;
                followTimer = followTimerAmount;
                agent.SetDestination(player.position);
            }

            if (followPlayer && !seePlayer)
            {
                if (followTimer > 0)
                {
                    followTimer -= Time.deltaTime;
                }
                else if (followTimer <= 0)
                {
                    followPlayer = false;
                }
                agent.SetDestination(player.position);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }

}
