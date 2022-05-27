using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HP //HP 구현 클래스
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
    public Vector2 force = new Vector2(10f, 10f); // 이 두개는
    public Vector2 force2 = new Vector2(-5f, 8f); // 점프수치 관련 float 변수
    private Rigidbody2D rg;
    public bool onWall = true; // 벽에 붙었을때만 점프할수 있게해주는 bool타입 변수
    private Coroutine wallTimer; // 벽에 부딛혔을때 일정시간 벽에 붙을수 있게 도와주는 코루틴함수
    
    public bool right_left = false; // 좌우를 결정해주는 변수
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&onWall) // 클릭시에 벽에 닿았는지 여부와 UI클릭시 중복클릭 방지
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                rg.velocity = Vector2.zero; // 물리수치가 합연산 되는걸 막기위한 이동값 초기화
                if (wallTimer != null) // 코루틴 널 체크
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
        if (collision.gameObject.tag == "Wall") // Wall 태그를 가지고있는 오브젝트에 부딛혔을때 실행되는 함수
        {
            rg.velocity = Vector2.zero;
            rg.gravityScale = 0.0f;
            right_left = !right_left;
            onWall = true;
            wallTimer = StartCoroutine(Walltimer()); // 벽에 일정시간 붙을수 있게 도와주는 코루틴 실행과 동시에 코루틴 변수 초기화
        }
    }

    private IEnumerator Walltimer()
    {
        yield return new WaitForSeconds(0.5f); // 벽에 매달리는 시간(추후 수정시 수치조정만 하면됨)
        rg.gravityScale = 0.5f; // 중력값을 복구하여 캐릭터를 떨어지게 만듬
    }
}
