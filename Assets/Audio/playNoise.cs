using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playNoise : MonoBehaviour
{
    public AudioManager manager;
    private void Update()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<AudioManager>();
        }
    }
    public void playSound(string sound)
    {
        manager.Play(sound);
    }
}
