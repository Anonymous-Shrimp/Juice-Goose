using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class rewindManager : MonoBehaviour
{
    public Slider bar;
    

    public bool rewind = false;

    public PostProcessVolume FX;
    private float FXWeight = 0;
    private PlayerMove player;
    public float juiceDecrease = 5;
    [HideInInspector]
    public float juice = 1;
    // Start is called before the first frame update
    void Start()
    {
        bar = FindObjectOfType<Slider>();
        FX.weight = FXWeight;
        player = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FX.weight > FXWeight)
        {
            FX.weight -= Time.deltaTime;
        }
        else if(FX.weight < FXWeight)
        {
            FX.weight += Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && juice > 0 && !FindObjectOfType<changeScore>().hasControl)
        {
            player.gameObject.SetActive(true);
            player.isDead = false;
            juice -= Time.deltaTime / juiceDecrease;
            rewind = true;
            FXWeight = 1;
        }
        else
        {
            rewind = false;
            //juice += Time.deltaTime / 3; 
            FXWeight = 0;
        }
        if(juice > 1)
        {
            juice = 1;
        }
        bar.value = juice;
    }
    
}
