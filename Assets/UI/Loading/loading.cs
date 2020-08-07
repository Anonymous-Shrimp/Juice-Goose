using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Animator anim;
    public PauseUI pause;
    

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    public void LoadSameLevel()
    {

        
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex));
    }


    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        yield return new WaitForSeconds(1);
        if (!(SceneManager.GetActiveScene().buildIndex == 1))
        {
            pause.boolPause(false);
        }

        
        loadingScreen.SetActive(true);
        if (pause != null)
        {
            pause.canPause = false;
        }
        Debug.Log("Switch scene to " + sceneIndex);
        anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        loadingScreen.SetActive(false);
        if (pause != null)
        {
            pause.canPause = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(wait(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
