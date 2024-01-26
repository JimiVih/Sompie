using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;

    public float coolDownTime;
    float coolTimer;

    public float rayDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coolTimer > 0)
        {
            coolTimer -= Time.deltaTime;
        }

        if(coolTimer <= 0 && Input.GetMouseButtonDown(0))
        {
            coolTimer = coolDownTime;
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, rayDistance))
        {
            Debug.Log(hit.transform.gameObject);
        }
    }


}
