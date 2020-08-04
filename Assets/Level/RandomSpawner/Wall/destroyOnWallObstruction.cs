using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnWallObstruction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Wall"))
        {
            if(Vector3.Distance(transform.position, g.transform.position) < 7)
            {
                Destroy(gameObject);
            }
        }
    }
}
