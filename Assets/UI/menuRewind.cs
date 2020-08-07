using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class menuRewind : MonoBehaviour
{
    public bool rewind = false;
    public Animator rewindFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rewind)
        {
            rewindFX.SetTrigger("Rewind");
        }
        else
        {
        }
    }
    public void rewindFXAnim()
    {
        rewind = true;
        
    }
}
