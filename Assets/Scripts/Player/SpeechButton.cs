using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechButton : MonoBehaviour
{
    float timer;
    public float timerAmount;

    AudioSource audioSource;
    public AudioClip[] speeches;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Talk();
                timer = timerAmount;
            }
        }
    }

    void Talk()
    {
        int i = Random.Range(0, speeches.Length);
        audioSource.clip = speeches[i];
        audioSource.Play();
    }
}
