using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pause_UI;
    private bool onpaulse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseUI()
    {
        if (!onpaulse)
        {
            Time.timeScale = 0;
            onpaulse = true;
            pause_UI.SetActive(true);
        }
    }
    public void OffPauseUI()
    {
        onpaulse = false;
        Time.timeScale = 1;
        pause_UI.SetActive(false);
    }
}
