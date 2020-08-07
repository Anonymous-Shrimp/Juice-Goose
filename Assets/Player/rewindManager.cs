using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;

public class rewindManager : MonoBehaviour
{
    public Slider bar;
    

    public bool rewind = false;

    public PostProcessVolume FX;
    private float FXWeight = 0;
    private PlayerMove player;
    public float juiceDecrease = 5;

    private bool rewindTouch = false;
    

    [HideInInspector]
    public float juice = 1;

    public bool rewindPress = false;
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

        rewindTouch = false;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPos = new Vector3(Input.touches[i].position.x / Screen.currentResolution.width - 0.2f, Input.touches[i].position.y / Screen.currentResolution.height - 0.2f);
            print(touchPos);
            if (touchPos.x < 0)
            {
                rewindTouch = true;
            }  
            
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || rewindTouch)
        {
            rewindPress = true;
        }
        else
        {
            rewindPress = false;
        }
        if (FX.weight > FXWeight)
        {
            FX.weight -= Time.deltaTime;
        }
        else if(FX.weight < FXWeight)
        {
            FX.weight += Time.deltaTime;
        }
        if (rewindPress && juice > 0 && !FindObjectOfType<changeScore>().hasControl)
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
        player.gameObject.GetComponent<Animator>().enabled = !rewind;
        FindObjectOfType<PauseUI>().lowPassRewind = rewind;
    }
    
}
