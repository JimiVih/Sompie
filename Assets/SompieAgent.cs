using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SompieAgent : MonoBehaviour
{
    Transform eyes;
    Transform player;
    [SerializeField]
    float sightDistance;
    public float followTimerAmount;
    float followTimer;
    NavMeshAgent agent;

    public LayerMask playerMask;
    [SerializeField]
    bool seePlayer;
    bool followPlayer;

    Vector3 SompieVelocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        eyes = transform.Find("Eyes");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SompieVelocity = agent.velocity;
        RaycastHit hit;

        seePlayer = Physics.Raycast(eyes.position, eyes.forward, sightDistance, playerMask);

        Debug.DrawRay(eyes.position, eyes.forward * sightDistance, Color.green);

        if (seePlayer)
        {
            followPlayer = true;
            followTimer = followTimerAmount;
            agent.SetDestination(player.position);
        }

        if(followPlayer && !seePlayer)
        {
            if(followTimer > 0)
            {
                followTimer -= Time.deltaTime;
            }
            else if(followTimer <= 0)
            {
                followPlayer = false;
            }
            agent.SetDestination(player.position);
        }
    }

}
