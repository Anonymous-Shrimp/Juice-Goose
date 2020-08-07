using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialTrigger : MonoBehaviour
{
    Tutorial tutorial;
    // Start is called before the first frame update
    void Start()
    {
        tutorial = FindObjectOfType<Tutorial>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tutorial.collisionTriggered(true);
        }
    }
}
