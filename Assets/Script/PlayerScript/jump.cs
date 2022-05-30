using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


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
    private HP playerhp = new HP(); //Hp Ŭ���� ��ü ����
    public bool onWall = true; // ���� �پ������� �����Ҽ� �ְ����ִ� boolŸ�� ����
    private Coroutine wallTimer; // ���� �ε������� �����ð� ���� ������ �ְ� �����ִ� �ڷ�ƾ�Լ�
    
    public bool right_left = false; // �¿츦 �������ִ� ����

    private Animator anim;
    private SpriteRenderer spr;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Jump();
    }

    public void Jump() // ����ó�� ���� �޼ҵ�
    {
        if (Input.GetMouseButtonDown(0) && onWall) // Ŭ���ÿ� ���� ��Ҵ��� ���ο� UIŬ���� �ߺ�Ŭ�� ����
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                rg.velocity = Vector2.zero; // ������ġ�� �տ��� �Ǵ°� �������� �̵��� �ʱ�ȭ
                anim.SetTrigger("Jump");
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

    public void OnCollisionEnter2D(Collision2D collision) // �ݶ��̴� �浹
    {
        if (collision.gameObject.tag == "Wall") // Wall �±׸� �������ִ� ������Ʈ�� �ε������� ����Ǵ� �Լ�
        {
            rg.velocity = Vector2.zero;
            rg.gravityScale = 0.0f;
            right_left = !right_left;
            onWall = true;
            spr.flipX = !spr.flipX;
            anim.SetTrigger("Grap");
            wallTimer = StartCoroutine(Walltimer()); // ���� �����ð� ������ �ְ� �����ִ� �ڷ�ƾ ����� ���ÿ� �ڷ�ƾ ���� �ʱ�ȭ
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) // Ʈ���� �浹
    {
        if (collision.gameObject.tag.Equals("Saw")) // Saw �ǰݰ��� ó������
        {
            if (!playerhp.infinity && HP.hp > 1)
            {
                StartCoroutine(Infinity());
                anim.SetTrigger("Hit");
            }
            StartCoroutine(playerhp.Infinity());
            if (HP.hp <= 0)
            {
                anim.SetTrigger("Hit");
                Time.timeScale = 0;
                StartCoroutine(Resetcounter());
            }
        }
    }

    private IEnumerator Resetcounter() // ����� ī���� �ڷ�ƾ
    {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HP.hp = 3;
        Time.timeScale = 1;
    }
    private IEnumerator Infinity() // �ǰݽ� ����ó�� �ڷ�ƾ
    {
        spr.color = new Color(255, 255, 255, 0.5f);
        yield return new WaitForSeconds(2.0f);
        spr.color = new Color(255, 255, 255, 255);
    }

    private IEnumerator Walltimer() // ���� �����ð� �Ŵ޸��� �ڷ�ƾ
    {
        yield return new WaitForSeconds(0.5f); // ���� �Ŵ޸��� �ð�(���� ������ ��ġ������ �ϸ��)
        rg.gravityScale = 0.5f; // �߷°��� �����Ͽ� ĳ���͸� �������� ����
    }
}