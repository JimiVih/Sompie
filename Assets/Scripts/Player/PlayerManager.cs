using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    PauseManager pauseManager;
    public bool pause;

    // Update is called once per frame
    void Update()
    {
        pause = pauseManager.paused;
    }
}
