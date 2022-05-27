using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    private HP playerhp = new HP(); //Hp Ŭ���� ��ü ����
    private SpriteRenderer sr; // �÷��̾� ���� ������ ���� ��������Ʈ ������ ������Ʈ

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Saw"))
        {
            if (!playerhp.infinity && HP.hp > 1)
            {
                StartCoroutine(Infinity());
            }
            StartCoroutine(playerhp.Infinity());
            if(HP.hp <= 0)
            {
                Time.timeScale = 0;
                StartCoroutine(Resetcounter());
            }
        }
    }

    private IEnumerator Resetcounter()
    {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HP.hp = 3;
        Time.timeScale = 1;
    }
    private IEnumerator Infinity()
    {
        sr.color = new Color(255,255,255,0.5f);
        yield return new WaitForSeconds(2.0f);
        sr.color = new Color(255, 255, 255, 255);
    }
}
