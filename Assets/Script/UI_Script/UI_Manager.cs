using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject[] uiList;
    public Transform player;
    public Text[] textUI;
    private void Awake()
    {
        Time.timeScale = 0;
        Application.targetFrameRate = 60;
    }

    public void GameStart()
    {
        uiList[0].SetActive(false);
        Time.timeScale = 1;
        uiList[1].SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        uiList[2].SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        uiList[2].SetActive(false);
    }
    public void Restart()
    {
        uiList[3].SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HP.hp = 3;
        Time.timeScale = 1;
        uiList[0].SetActive(false);
        uiList[1].SetActive(true);
    }

    private void Update()
    {
        textUI[0].text = (int)player.position.y+"";
        textUI[1].text = "x " + HP.hp;
        textUI[2].text = (int)player.position.y + "";
    }
}
