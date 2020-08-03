using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    PlayerMove player;
    Vector3 startingPos;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startingPos + new Vector3(player.transform.position.x / 10, player.transform.position.y / 10);
    }
}
