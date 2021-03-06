﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class changeScore : MonoBehaviour
{
    public Score scoreScript;
    public bool canChangeScore = false;
    public Text scoreText;
    public Color textColor;
    public Transform bird;
    public CinemachineVirtualCamera cam;
    public float camSize;
    public Vector3 birdPos;
    public bool hasControl = true;
    public float barSmooth = 1f;
    public Animator bar;
    public bool barFade;
    public bool canFade;
    private bool resetBoost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasControl)
        {
            scoreScript.canChange = canChangeScore;
            scoreScript.score = 0;
            scoreText.color = textColor;
            cam.m_Lens.OrthographicSize = camSize;
            bird.position = birdPos;
            if (FindObjectOfType<followTarget>() != null)
            {
                FindObjectOfType<followTarget>().smoothSpeed = barSmooth;
            }
            bar.SetBool("Fade", barFade);
            FindObjectOfType<PlayerMove>().forceAmnt = 0;
            bar.SetBool("CanFade", canFade);
        }
        else
        {
            
        }
        scoreScript.canChange = canChangeScore;
    }
}
