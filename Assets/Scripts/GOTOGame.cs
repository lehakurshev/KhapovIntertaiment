using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOTOGame : MonoBehaviour
{
    private int sceneToContinue;

    public void StartGame()
    {
        PlayerPrefs.SetInt("SavedScene", 1);
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue == 0)
            return;

        SceneManager.LoadScene(sceneToContinue);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}