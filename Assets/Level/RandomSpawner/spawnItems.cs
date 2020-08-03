using UnityEngine;
[System.Serializable]
public class spawnItems
{
    public string name;
    public GameObject item;
    public bool isGrounded;
    public float freq;
    public Vector2 spawnRange;
    public Vector3 offset;

    [HideInInspector]
    public float spawn = -1000;

    
}
