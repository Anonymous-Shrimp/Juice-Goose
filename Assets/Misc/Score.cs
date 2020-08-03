using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float score = 0;
    private Transform player;
    public bool canChange = true;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (canChange)
        {
            score = Mathf.Round(player.position.x);
            if(score < 0)
            {
                score = 0;
            }
            scoreText.text = score.ToString();

        }
    }
}
