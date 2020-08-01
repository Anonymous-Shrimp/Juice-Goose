using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public Transform player;
    public float xOffset = 5;
    public float zOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + xOffset, 0, zOffset);
    }
}
