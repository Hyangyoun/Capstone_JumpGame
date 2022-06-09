using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_wall : MonoBehaviour
{
    public GameObject[] wall;
    public GameObject[] sawL;
    public GameObject[] sawR;
    public GameObject[] backGround;
    private float posY_Back = 45.30125f;
    private float posY = 17.5f;
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
        if(posY < 110)
        {
            if (collision.gameObject.tag.Equals("CTrigger"))
            {
                Instantiate(wall[0], new Vector2(0, posY), Quaternion.identity);
                Instantiate(sawL[0], new Vector2(Random.Range(-2f, -1f), Random.Range(posY - 4, posY - 3)), Quaternion.identity);
                Instantiate(sawR[0], new Vector2(Random.Range(1f, 2f), Random.Range(posY + 2, posY + 3)), Quaternion.identity);
                Destroy(collision.gameObject);
                posY += 12.0f;
            }

            if (collision.gameObject.tag.Equals("Respawn"))
            {
                Instantiate(backGround[0], new Vector2(0, posY_Back), Quaternion.identity);
                Destroy(collision.gameObject);
                posY_Back += 31.6875f;
            }
        }

        else if(posY >= 110)
        {
            if (collision.gameObject.tag.Equals("CTrigger"))
            {
                Instantiate(wall[1], new Vector2(0, posY), Quaternion.identity);
                Instantiate(sawL[1], new Vector2(Random.Range(-2f, -1f), Random.Range(posY - 4, posY - 3)), Quaternion.identity);
                Instantiate(sawR[1], new Vector2(Random.Range(1f, 2f), Random.Range(posY + 2, posY + 3)), Quaternion.identity);
                Destroy(collision.gameObject);
                posY += 12.0f;
            }

            if (collision.gameObject.tag.Equals("Respawn"))
            {
                Instantiate(backGround[1], new Vector2(0, posY_Back), Quaternion.identity);
                Destroy(collision.gameObject);
                posY_Back += 31.6875f;
            }
        }
    }
}
