using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_wall : MonoBehaviour
{
    public GameObject wall;
    private float posY = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("CTrigger"))
        {
            Instantiate(wall, new Vector2(0, posY), Quaternion.identity);
            Destroy(collision.gameObject);
            posY += 12.0f;
        }
    }
}
