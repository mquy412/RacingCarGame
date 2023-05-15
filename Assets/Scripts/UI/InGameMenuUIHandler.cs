using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuUIHandler : MonoBehaviour
{
    //Other components
    Canvas canvas;
    public GameObject pauseCanvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();

        canvas.enabled = false;

        //Hook up events
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }
   

    public void OnRaceAgain()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 + 1);
    } 

    public void NextStage()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreStage()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void OnExitToMainMenu()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        if (GameManager.instance.GetGameState() != GameStates.raceOver)
        {
            GameManager.instance.OnRaceCompleted();
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    public void Pause()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    public void Reset()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        if (GameManager.instance.GetGameState() != GameStates.raceOver)
        {
            GameManager.instance.OnRaceCompleted();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 + 1);
            GameManager.instance.OnRaceStart();
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 + 1);
        }
    }

    //Events 
    void OnGameStateChanged(GameManager gameManager)
    {
        if (GameManager.instance.GetGameState() == GameStates.raceOver)
        {
            StartCoroutine(ShowMenuCO());
        }
    }
    IEnumerator ShowMenuCO()
    {
        yield return new WaitForSeconds(1);
        if (CarLapCounter.isWin == false)
        {
            Debug.Log("false");
            nextStageButton.SetActive(false);
        }
        else
        {
            nextStageButton.SetActive(true);
        }    

        canvas.enabled = true;
    }

    void OnDestroy()
    {
        //Unhook events
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
    }
    public GameObject nextStageButton;
}
