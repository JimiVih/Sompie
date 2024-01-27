using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    bool optionOpen;

    private void Start()
    {
        optionOpen = false;
    }

    public void StartGame()
    {
        StartCoroutine(GameStart());
    }
    IEnumerator GameStart()
    {
        print("Start Game!");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("level_0");
    }
    public void GameOptions()
    {
        if(optionOpen)
        {
            optionOpen = false;
            print("options closed");
        }
        else if(!optionOpen)
        {
            optionOpen = true;
            print("options opened!");
        }
    }
    public void ExitGame()
    {
        print("Exit Game!");
        Application.Quit();
    }
}
