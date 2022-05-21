using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesroyWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 view = Camera.main.WorldToScreenPoint(transform.position);
        if (view.y < -1750)
        {
            Destroy(gameObject);
        }
    }
}
