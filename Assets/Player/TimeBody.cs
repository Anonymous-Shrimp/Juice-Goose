using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    bool isRewinding = false;

    public float recordTime = 10f;

    public List<PointInTime> pointsInTime;

    Rigidbody2D rb;

    public rewindManager manager;

    private float forceAmmt = 0;

    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<rewindManager>();
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.rewind)
            StartRewind();
        else
            StopRewind();
    }

    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            rb.velocity = pointInTime.velocity;
            if (GetComponent<PlayerMove>() != null)
            {
                GetComponent<PlayerMove>().forceAmnt = pointInTime.forceAmmt;
            }
            
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
        if(GetComponent<PlayerMove>() != null)
        {
            forceAmmt = GetComponent<PlayerMove>().forceAmnt;
        }
        else
        {
            forceAmmt = 0;
        }
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation, rb.velocity, forceAmmt));
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}