using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    public GameObject cloud;
    public PlayerMove player;
    float num;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - num >= 1)
        {
            num = player.transform.position.x;
            Instantiate(cloud, new Vector3(player.transform.position.x + 1000, Random.Range(50, 1000), 200), Quaternion.identity);
        
        }
    }
}
