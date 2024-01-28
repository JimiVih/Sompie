using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    PlayerManager playerManager;
    CharacterMovement characterMovement;
    public collectible col;
    [SerializeField]
    public Animator pistolAnimation, konepistooliAnimation;
    public AudioSource gunAudio;
    public AudioClip pistolClip, konepistooliClip;

    public Transform Pistol, konepistooli;

    public float coolDownTime;
    float coolTimer;
    float velocity;

    public float rayDistance;
    public float damage;

    bool suomiKP;
    bool handgun;

    
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        handgun = true;
        suomiKP = false;
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

            if (coolTimer <= 0 && Input.GetMouseButton(0))
            {
                coolTimer = coolDownTime;
                Shoot();
            }
        }

        WeaponCycle();
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickItem();
        }

    }

    void WeaponCycle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            damage = 15;
            coolDownTime = 1.5f;
            handgun = true;
            suomiKP = false;
            Pistol.gameObject.SetActive(true);
            konepistooli.gameObject.SetActive(false);
            gunAudio.clip = pistolClip;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            damage = 5;
            coolDownTime = .2f;
            handgun = false;
            suomiKP = true;
            Pistol.gameObject.SetActive(false);
            konepistooli.gameObject.SetActive(true);
            gunAudio.clip = konepistooliClip;
        }
    }

    void Shoot()
    {
        if (handgun)
        {
            pistolAnimation.SetTrigger("Shoot");
        }
        else if(suomiKP)
        {
            konepistooliAnimation.SetTrigger("shoot");
        }
        
        gunAudio.Play();
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

    void PickItem()
    {
        Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(.0f, .0f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, rayDistance))
        {
            Debug.Log(hit.transform.gameObject);
            if (hit.transform.tag == "collect")
            {
                
                GameObject collected = hit.transform.gameObject;

                Destroy(collected);
                col.collected += 1;

                
            }

            if(hit.transform.tag == "car")
            {
                col.WinGame();
            }
        }
    }


}
