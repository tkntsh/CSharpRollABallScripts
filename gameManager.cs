using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    //global access
    public static gameManager Instance;

    //gameobjects needed for scoring system
    public Text scoreText;
    public Text timerText;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject mainMenuPanel;
    public GameObject instructionPanel;
    public GameObject gamePanel;
    private int score = 0;
    private float timeRemaining = 60f;
    private bool isGameActive = true;
    private GameObject[] collectibles;
    public GameObject player;
    private Vector3 playerStartPosition;
    public AudioSource audioSource;

    //when application runs for the first time this will be the first to execute
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        //
        else
        {
            Destroy(gameObject);
        }
    }

    //method to find all gameobjects with the tag "collectible"
    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");

        //storing player starting position
        if(player != null)
        {
            playerStartPosition = player.transform.position;
        }
    }

    //method to update timelimit per frame as game is running
    private void Update()
    {
        if(isGameActive)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString() + " secs";

            //when theres no time left endgame condition is set false and lose panel is shown
            if(timeRemaining <= 0)
            {
                endGame(false);
            }
        }
    }

    //method to add score
    public void addScore(int points)
    {
        //updating score
        score += points;

        //if audiosource component in unity isnt empty audio plays
        if(audioSource != null)
        {
            audioSource.Play();
        }

        //updating score
        Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score;

        //if score = 100, game over
        if(score == 100)
        {
            endGame(true);
        }
    }

    //method to handle end result of the game
    private void endGame(bool hasWon)
    {
        isGameActive = false;

        //conditional statement to check if user won or lost 
        if(hasWon)
        {
            showWinPanel();
        }
        else
        {
            showLosePanel();
        }
    }

    //method to show winning panel
    private void showWinPanel()
    {
        Debug.Log("Winner");
        deactivateAllPanel();
        winPanel.SetActive(true);
    }

    //method to show losing panel
    private void showLosePanel()
    {
        Debug.Log("Loser");
        deactivateAllPanel();
        losePanel.SetActive(true);
    }

    //method to deactivate all panels
    public void deactivateAllPanel()
    {
        mainMenuPanel.SetActive(false);
        instructionPanel.SetActive(false);
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    //method to start timer and update timer
    public void startGame()
    {
        isGameActive = true;
        timeRemaining = 60f;
        score = 0;
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString() + " secs";
        //setting other game objects off
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    //method to handle game reset
    public void resetGame()
    {
        //reseting all collectibles
        foreach(GameObject collectible in collectibles)
        {
            collectible.SetActive(true);
        }

        //reset score
        score = 0;
        scoreText.text = "Score: " + score;

        //reset timer
        timeRemaining = 60f;
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString() + " secs";

        //reseting player position
        if(player != null)
        {
            player.transform.position = playerStartPosition;
            Rigidbody rb = player.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }

        //return to main menu panel
        deactivateAllPanel();
        mainMenuPanel.SetActive(true);

        //stop the game
        isGameActive = false;
    }

    //when user wants to quit application
    public void quitBtn()
    {
        Application.Quit();
    }
}
