using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject SpawnLocation;
    private void Start()
    {
        showMainMenu();
    }
    private void OnEnable()
    {
        EventManager.onStartGame += showGameUI;
        EventManager.onPlayerDeath += StartChange;
    }
    private void OnDisable()
    {
        //Debug.Log("Show game UI");
        EventManager.onStartGame -= showGameUI;
        EventManager.onPlayerDeath -= StartChange;
    }
    void showMainMenu()
    {
        gameUI.SetActive(false);
        mainMenu.SetActive(true);
    }
    void StartChange()
    {
        Invoke("showMainMenu", 3f);
    }
    void showGameUI()
    {
        Debug.Log("Show game UI");
        gameUI.SetActive(true);
        mainMenu.SetActive(false);
        Instantiate(playerPrefab, SpawnLocation.transform.position, Quaternion.identity);
    }
   
}
