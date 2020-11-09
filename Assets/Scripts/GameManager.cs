using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //private Player player;
    private SpawnManager spawnManager;
    private UIManager uIManager;
    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
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
}
