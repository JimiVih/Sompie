using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPScamera : MonoBehaviour
{
    PlayerManager playerManager;

    [SerializeField]

    Camera _camera;

    public Transform body;

    public float sensitivity;
    float xRotation = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        _camera = Camera.main;
        if (!playerManager.pause)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (playerManager.pause)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerManager.pause)
        {
            controlAll();
        }

    }

    void controlAll()
    {
        FollowMouse();
    }

    void FollowMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}
