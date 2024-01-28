using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectible : MonoBehaviour
{
    public int collected;
    public bool allCollected;

    private void Start()
    {
        allCollected = false;
    }
    private void Update()
    {
        if (collected == 3)
        {
            allCollected = true;
        }
    }

    public void WinGame()
    {
        if (allCollected)
        {
            SceneManager.LoadScene("menu");
        }
        
    }


}
