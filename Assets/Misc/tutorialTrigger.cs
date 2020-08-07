using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (FindObjectOfType<Tutorial>() != null)
            {
                FindObjectOfType<Tutorial>().collisionTriggered(true);
            }
            if (FindObjectOfType<HardTutorial>() != null)
            {
                FindObjectOfType<HardTutorial>().collisionTriggered(true);
            }
        }
    }
}
