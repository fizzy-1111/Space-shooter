using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonClick : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    public static bool GameisPause = false;
    private void OnEnable()
    {
        EventManager.onResume += continousGame;
    }
    private void OnDisable()
    {
        EventManager.onResume -= continousGame;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Can Access");
            if (GameisPause)
                Resume();
            else Pause();
        }
    }
    public void Click()
    {
        GameObject tempt = GameObject.FindGameObjectWithTag("Player");
        if (tempt == null)
            EventManager.StartGame();
        else
        {
            tempt = GameObject.FindGameObjectWithTag("Player");
            Destroy(tempt);
            EventManager.PlayerDeath();
            Resume();

        }
    }
    public void Resume()
    {

        GameObject tempt = GameObject.FindGameObjectWithTag("Player");
        if(tempt!=null)
        EventManager.ReSume();

    }
    void continousGame()
    {
        //Debug.Log("Can Access");
        if (mainMenu != null)
        {
            mainMenu.SetActive(false);
            Time.timeScale = 1;
            GameisPause = false;
        }
    }
    void Pause()
    {
            mainMenu.SetActive(true);
            Time.timeScale = 0;
            GameisPause = true;
    }
    public void Quit()  
    {
        Application.Quit();
    }
}
