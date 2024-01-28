using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    PlayerManager playerManager;
    CharacterMovement characterMovement;
    [SerializeField]
    Animator handAnimator;
    public AudioSource pistolAudio;

    public float coolDownTime;
    float coolTimer;
    float velocity;

    public float rayDistance;
    public float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        handAnimator = Camera.main.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (!playerManager.pause)
        {
            

            if (coolTimer > 0)
            {
                coolTimer -= Time.deltaTime;
            }

            if (coolTimer <= 0 && Input.GetMouseButtonDown(0))
            {
                coolTimer = coolDownTime;
                Shoot();
            }
        }



    }

    void WeaponCycle()
    {
        //weapons array
    }

    void Shoot()
    {
        handAnimator.SetTrigger("Shoot");
        pistolAudio.Play();
        Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(.0f, .0f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, rayDistance))
        {
            Debug.Log(hit.transform.gameObject);
            if(hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<HealthManager>().DoDamage(damage);


                print("Hit " + hit.transform.gameObject.name);
            }
        }
    }


}
