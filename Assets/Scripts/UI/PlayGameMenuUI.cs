using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameMenuUI : MonoBehaviour
{
    public GameObject canvasTutorial;
    public GameObject canvasInfo;
    public void PlayGame()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void Info()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        canvasInfo.SetActive(true);
    }
    public void Tutorial()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        canvasTutorial.SetActive(true);
    }
    public void ExitTutorial()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        canvasTutorial.SetActive(false);
    }
    public void ExitInfo()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SoundGame>().clickButton();
        canvasInfo.SetActive(false);
    }

    public void ChangeSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
