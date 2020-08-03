using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    public Sprite[] clouds;
    PlayerMove player;
    Vector3 startingPos;
    public float destroyDistance = 100;
    public SpriteRenderer render;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        render.sprite = clouds[Random.Range(0, clouds.Length)];
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startingPos + (player.transform.position / 7);
        if (player.transform.position.x - transform.position.x > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
