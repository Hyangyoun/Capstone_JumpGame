using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControl : MonoBehaviour
{
    private Transform trans;
    private float posX;
    public float minPos;
    public float maxPos;
    private bool triger = true;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        posX = transform.position.x;

        minPos = posX - minPos;
        maxPos = posX + maxPos;
    }

    // Update is called once per frame
    void Update()
    {
        //trans.Rotate(new Vector3(0, 0, 100.0f * Time.deltaTime));

        if (triger)
        {
            transform.Translate(Vector2.right * 1.0f*Time.deltaTime);
            if(transform.position.x >= maxPos)
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
}
