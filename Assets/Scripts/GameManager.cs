using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;
    //private SpawnManager spawnManager;
    private UIManager uIManager;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        //spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

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
