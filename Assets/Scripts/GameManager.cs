using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    private UIManager uIManager;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    public void GameOver()
    {
        uIManager.GameOver();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        player.PauseGame();
        uIManager.PauseGame();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        player.ResumeGame();
        uIManager.ResumeGame();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }
}
