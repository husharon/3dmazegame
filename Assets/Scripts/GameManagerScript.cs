using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    TimeManager TM;
    public int coinCount = 0;
    public int coinsTotal = 0;

    public GameObject door;
    public Canvas hint;
    public Text hintText;
    public Text coinsLeft;
    public Text outOfTime;
    public Text winStat;
    public Button pauseButton;
    public Button winScreen;

    private bool hintUsed = false;
    private bool paused = false;
    public bool gameWon = false;
    private bool gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.Find("Canvas").GetComponent<TimeManager>();
        door.SetActive(false);
        hint.gameObject.SetActive(false);
        outOfTime.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        coinsTotal = coinCount;
        UpdateUI();
    }

    void Update()
    {
        // press h for hint
        if (Input.GetKey(KeyCode.H) && !hintUsed)
        {
            // hint can only be used once
            hintUsed = true;

            // disable Press H for help text
            hintText.gameObject.SetActive(false);

            // enable hint map for 3 seconds
            StartCoroutine(HintActivationRoutine());
        }

        // press m for menu
        if (Input.GetKey(KeyCode.M)) {
            SceneManager.LoadScene(0);
        }

        // press p to pause
        if (Input.GetKey(KeyCode.P))
        {
            PauseManager();
        }

        // game over
        if (gameEnd && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!gameEnd)
        {
            Time.timeScale = 1.0f;
        }

        if (gameWon)
        {
            winScreen.gameObject.SetActive(true);
            winStat.text = "You completed " + SceneManager.GetActiveScene().name;
        } else
        {
            winScreen.gameObject.SetActive(false);
        }
    }

    private IEnumerator HintActivationRoutine()
    {
        hint.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        hint.gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        //coin UI management
        if (coinCount >= 0)
        {
            coinsLeft.text = "Coins Left: " + coinCount.ToString() + "/" + coinsTotal.ToString();
        }
        if (coinCount == 0)
        {
            door.SetActive(true);
        }
    }

    public void PauseManager()
    {
        if (!paused)
        {
            pauseButton.gameObject.SetActive(true);
            Time.timeScale = 0;
            paused = true;

        }
        else
        {
            pauseButton.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            paused = false;
        }
    }

    public void GameOver()
    {
        outOfTime.gameObject.SetActive(true);
        Time.timeScale = 0;
        gameEnd = true;
    }

}
