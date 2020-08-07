using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    
    public Animator directions;
    public PlayerMove playerManager;
    public rewindManager rewind;
    public string[] texts;
    public Text popupText;
    int popUpIndex = 0;
    int textIndex = 0;
    float waitTime = 2f;
    bool collisionTrigger = false;
    
    // Start is called before the first frame update
    void Start()
    {
        directions.SetBool("Faded", true);
    }

    // Update is called once per frame
    void Update()
    {
        
        popupText.text = texts[textIndex];
        if (popUpIndex == 0)
        {
            if (waitTime <= 0)
            {
                waitTime = 3.5f;
                directions.SetBool("Faded", false);
                popUpIndex++;
                
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }else if (popUpIndex == 1)
        {
            if (waitTime <= 0)
            {
                waitTime = 2f;
                directions.SetBool("Faded", true);
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }else if (popUpIndex == 2)
        {
            if (waitTime <= 0)
            {
                waitTime = 3.5f;
                textIndex++;
                directions.SetBool("Faded", false);
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 3){
            if(playerManager.upPress || playerManager.downPress)
            {
                directions.SetBool("Faded", true);
                popUpIndex++;
            }
        }else if(popUpIndex == 4)
        {
            if (collisionTrigger)
            {
                collisionTrigger = false;
                textIndex++;
                directions.SetBool("Faded", false);
                popUpIndex++;
            }
        }else if(popUpIndex == 5)
        {
            if (rewind.rewindPress)
            {
                directions.SetBool("Faded", true);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 6)
        {
            if (collisionTrigger)
            {
                collisionTrigger = false;
                textIndex++;
                directions.SetBool("Faded", false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 7)
        {
            if (waitTime <= 0)
            {
                waitTime = 2f;
                directions.SetBool("Faded", true);
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 8)
        {
            if (waitTime <= 0)
            {
                waitTime = 3.5f;
                textIndex++;
                directions.SetBool("Faded", false);
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }else if (popUpIndex == 9)
        {
            FindObjectOfType<loading>().LoadLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<loading>().LoadLevel(1);
        }

    }
    public void collisionTriggered(bool trigger)
    {
        collisionTrigger = trigger;
    }

}
