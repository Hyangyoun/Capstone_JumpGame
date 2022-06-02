using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_BackGround : MonoBehaviour
{
    public GameObject backGround;
    private float posY_Back = 61.675f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            Instantiate(backGround, new Vector2(0, posY_Back), Quaternion.identity);
            posY_Back += 25.35f;
        }
    }
}
