using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseUI : MonoBehaviour
{
    public bool canPause = false;
    public bool isPaused = false;
    public GameObject pauseUI;
    public AudioMixer audioGroup;
    public int lowPassNormal = 5000;

    public int lowPassPaused = 600;
    public bool lowPass = false;
    public bool lowPassRewind = false;

    // Start is called before the first frame update
    void Start()
    {
        audioGroup.SetFloat("pauseLowPass", lowPassNormal);

    }

    // Update is called once per frame
    void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    pauseUI.SetActive(true);
                    Time.timeScale = 0;
                    lowPass = true;
                }
                else
                {
                    pauseUI.SetActive(false);
                    Time.timeScale = 1;
                    lowPass = false;
                }
            }
        }
        else
        {
            isPaused = false;
        }
        if(lowPassRewind || lowPass)
        {
            audioGroup.SetFloat("pauseLowPass", lowPassPaused);
        }
        else
        {
            audioGroup.SetFloat("pauseLowPass", lowPassNormal);
        }
    }
    
    public void boolPause(bool pauser)
    {
        isPaused = pauser;
        if (isPaused)
        {
            pauseUI.SetActive(true);
            audioGroup.SetFloat("pauseLowPass", lowPassPaused);
            Time.timeScale = 0;
        }
        else
        {
            pauseUI.SetActive(false);
            audioGroup.SetFloat("pauseLowPass", lowPassNormal);
            Time.timeScale = 1;
        }
    }
}
