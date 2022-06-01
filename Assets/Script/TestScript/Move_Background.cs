using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Background : MonoBehaviour
{
    public Rigidbody2D player;
    private Transform bg;
    private float ps;
    // Start is called before the first frame update
    void Start()
    {
        bg = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        bg.Translate(Vector2.up * player.velocity / 5 * Time.deltaTime);
    }
}
