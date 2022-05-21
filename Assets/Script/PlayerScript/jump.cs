using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public Vector2 force = new Vector2(10f, 10f);
    public Vector2 force2 = new Vector2(-5f, 8f);
    private Rigidbody2D rg;
    public bool onWall = true;
    
    public bool aa = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&onWall)
        {
            rg.velocity = Vector2.zero;
            if(aa == false)
            {
                rg.gravityScale = 1;
                rg.AddForce(force, ForceMode2D.Impulse);
                onWall = false;
            }
            else
            {
                rg.gravityScale = 1;
                rg.AddForce(force2, ForceMode2D.Impulse);
                onWall = false;
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            rg.velocity = Vector2.zero;
            rg.gravityScale = 0.5f;
            aa = !aa;
            onWall = true;
        }
    }
}
