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
    private int treeCount = 0;
    [SerializeField]
    private Button replayButton;
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button pauseButton;
    [SerializeField]
    private Button resumeButton;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        replayButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);

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
        gameOverText.gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void PauseGame()
    {
        replayButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
    }
    public void ResumeGame()
    {
        resumeButton.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
    }
}
