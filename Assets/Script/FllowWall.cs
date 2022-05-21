using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowWall : MonoBehaviour
{
    public GameObject player;
    private Transform pPos;
    private Transform wallPos;
    // Start is called before the first frame update
    void Start()
    {
        pPos = player.GetComponent<Transform>();
        wallPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        wallPos.position = new Vector2(wallPos.position.x, pPos.position.y);
    }
}
