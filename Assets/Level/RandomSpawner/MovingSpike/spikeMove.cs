using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class spikeMove : MonoBehaviour
{
    public float speed;
    public CinemachineDollyCart cart;
    float recordTime = 5f;
    rewindManager manager;
    menuRewind managerMenu;

    public List<float> pointsInTime;
    bool isRewinding = false;
    // Start is called before the first frame update
    void Start()
    {

        speed = Random.Range(5f, 12f);
        if (FindObjectOfType<rewindManager>() != null)
        {
            manager = FindObjectOfType<rewindManager>();
        }
        else if (FindObjectOfType<menuRewind>() != null)
        {
            managerMenu = FindObjectOfType<menuRewind>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (manager != null)
        {
            if (manager.rewind)
            {
                Rewind();
            }
            else
            {
                cart.m_Position += speed * Time.deltaTime;
                Record();
            }
        }
        else
        {
            if (managerMenu.rewind)
            {
                Rewind();
            }
            else
            {
                cart.m_Position += speed * Time.deltaTime;
                Record();
            }
        }
        

        
        void Rewind()
        {
            if (pointsInTime.Count > 0)
            {
                float pointInTime = pointsInTime[0];
                cart.m_Position = pointInTime;
                isRewinding = true;
                pointsInTime.RemoveAt(0);
            }
            else
            {
                StopRewind();
            }

        }

        void Record()
        {
            if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
            {
                pointsInTime.RemoveAt(pointsInTime.Count - 1);
            }
           
            pointsInTime.Insert(0, cart.m_Position);
        }

       

        void StopRewind()
        {
            isRewinding = false;
        }
    }
}
