using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text gameOverText;
    private GameObject player;
    private int score;
    private int treeCount;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        if (player.transform.position.x >= 1f + treeCount * 4)
        {
            score++;
            treeCount++;
        }
        scoreText.text =score.ToString();
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
    }
}
