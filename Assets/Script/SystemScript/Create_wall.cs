using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_wall : MonoBehaviour
{
    public GameObject wall;
    public GameObject sawL;
    public GameObject sawR;
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
            Instantiate(sawL, new Vector2(Random.Range(-2f, 2f), Random.Range(posY - 5, posY - 3)), Quaternion.identity);
            Instantiate(sawR, new Vector2(Random.Range(-2f, 2f), Random.Range(posY + 1, posY + 5)), Quaternion.identity);
            Destroy(collision.gameObject);
            posY += 12.0f;
        }
    }
}
