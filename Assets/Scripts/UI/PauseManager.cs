using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject areYouSure;

    bool optionOpen;
    public bool paused;

    private void Start()
    {
        paused = false;
        optionOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                paused = true;
            }
            else if (paused)
            {
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                paused = false;
            }
            print(paused);
        }
    }

    public void AreYouSureToExit()
    {
        areYouSure.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void DontExit()
    {
        pauseMenu.SetActive(true);
        areYouSure.SetActive(false);
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
