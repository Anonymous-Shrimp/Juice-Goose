using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public spawnItems[] items;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //print(player.transform.position.x);
        foreach (spawnItems i in items)
        {
            if(Mathf.Abs(player.transform.position.x - i.spawn) > i.freq)
            {
                if (i.isGrounded)
                {
                    Instantiate(i.item, i.offset + new Vector3(player.transform.position.x, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(i.item, i.offset + new Vector3(player.transform.position.x,0) + new Vector3(0, Random.Range(i.spawnRange.x, i.spawnRange.y)), Quaternion.identity);
                }
                i.spawn = player.transform.position.x;
            }
        }
    }
}
