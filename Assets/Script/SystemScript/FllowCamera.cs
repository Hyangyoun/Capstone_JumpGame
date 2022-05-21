using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowCamera : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    private Transform cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        cameraPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = playerPos.position;
        pos.x = 0;
        pos.y += 3;
        pos.z = -10;
        cameraPos.position = Vector3.Lerp(cameraPos.position, pos, Time.deltaTime * 2.0f);
    }
}
