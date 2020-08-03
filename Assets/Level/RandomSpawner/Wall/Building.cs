using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject rooftop;
    public Vector3 rooftopOffset;
    int ran;
    // Start is called before the first frame update
    void Start()
    {

        foreach (GameObject i in levels)
        {
            i.SetActive(false);
        }
        ran = Random.Range(1, levels.Length);

        for (int i = 0; i < ran; i++)
        {
            levels[i].SetActive(true);
        }
        rooftop.transform.position = levels[ran - 1].transform.position + rooftopOffset;
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
