using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControlL : MonoBehaviour
{
    private float posX;
    public float minPos;
    public float maxPos;
    private bool triger = true;
    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;

        minPos = posX - minPos;
        maxPos = posX + maxPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (triger)
        {
            transform.Translate(Vector2.right * 1.0f*Time.deltaTime);
            if(transform.position.x >= maxPos)
            {
                triger = !triger;
            }
            if (transform.position.x >= 0)
            {
                triger = !triger;
            }
        }
        else if (!triger)
        {
            transform.Translate(Vector2.left * 1.0f * Time.deltaTime);
            if (transform.position.x <= minPos)
            {
                triger = !triger;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("SawTrigger"))
        {
            triger = !triger;
        }
    }
}
