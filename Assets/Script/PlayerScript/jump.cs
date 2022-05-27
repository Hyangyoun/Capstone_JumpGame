using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HP //HP ���� Ŭ����
{
    static public int hp = 3;
    public bool infinity;

    public IEnumerator Infinity()
    {
        if (!infinity)
        {
            --hp;
            infinity = true;
            yield return new WaitForSeconds(2f);
            infinity = false;
        }
    }
}
public class jump : MonoBehaviour
{
    public Vector2 force = new Vector2(10f, 10f); // �� �ΰ���
    public Vector2 force2 = new Vector2(-5f, 8f); // ������ġ ���� float ����
    private Rigidbody2D rg;
    public bool onWall = true; // ���� �پ������� �����Ҽ� �ְ����ִ� boolŸ�� ����
    private Coroutine wallTimer; // ���� �ε������� �����ð� ���� ������ �ְ� �����ִ� �ڷ�ƾ�Լ�
    
    public bool right_left = false; // �¿츦 �������ִ� ����
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&onWall) // Ŭ���ÿ� ���� ��Ҵ��� ���ο� UIŬ���� �ߺ�Ŭ�� ����
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                rg.velocity = Vector2.zero; // ������ġ�� �տ��� �Ǵ°� �������� �̵��� �ʱ�ȭ
                if (wallTimer != null) // �ڷ�ƾ �� üũ
                {
                    StopCoroutine(wallTimer);
                }

                if (right_left == false)
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
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") // Wall �±׸� �������ִ� ������Ʈ�� �ε������� ����Ǵ� �Լ�
        {
            rg.velocity = Vector2.zero;
            rg.gravityScale = 0.0f;
            right_left = !right_left;
            onWall = true;
            wallTimer = StartCoroutine(Walltimer()); // ���� �����ð� ������ �ְ� �����ִ� �ڷ�ƾ ����� ���ÿ� �ڷ�ƾ ���� �ʱ�ȭ
        }
    }

    private IEnumerator Walltimer()
    {
        yield return new WaitForSeconds(0.5f); // ���� �Ŵ޸��� �ð�(���� ������ ��ġ������ �ϸ��)
        rg.gravityScale = 0.5f; // �߷°��� �����Ͽ� ĳ���͸� �������� ����
    }
}
