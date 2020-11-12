using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text countDownText;
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
    private float timeLeft = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Game")
        {
            player = GameObject.Find("Player");
            replayButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "CountDown")
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadScene(2);
            }
            else if (timeLeft < 1)
            {
                countDownText.text = "1";
            }
            else if (timeLeft < 2)
            {
                countDownText.text = "2";
            }
            else if (timeLeft < 3)
            {
                countDownText.text = "3";
            }
        }
        else
        {
            UpdateScore();
        }
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
